using Microsoft.EntityFrameworkCore;
using Mouha.DemoAspNetCoreGithub.Data;
using Mouha.DemoAspNetCoreGithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class BookRepository
    {
        private readonly GestionLivreContext _context = null;
        public BookRepository(GestionLivreContext context) //Dependence injection
        {
            _context = context;
        }
        public async Task<int> AjouterNouveauLivre(BookModel model)
        {
            var nouveauLivre = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            nouveauLivre.BookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                nouveauLivre.BookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(nouveauLivre);
            await _context.SaveChangesAsync();

            return nouveauLivre.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var livres = new List<BookModel>();
            var tousleslivres = await _context.Books.ToListAsync();
            if (tousleslivres?.Any() == true)
            {
                foreach (var livre in tousleslivres)
                {
                    livres.Add(new BookModel()
                    {
                        Author = livre.Author,
                        Category = livre.Category,
                        Description = livre.Description,
                        Id = livre.Id,
                        LanguageId = livre.LanguageId,
                        //Language = livre.Language.Nom,
                        Title = livre.Title,
                        TotalPages = livre.TotalPages,
                        CoverImageUrl = livre.CoverImageUrl
                    });
                }
            }

            return livres;
        }

        public async Task<BookModel> GetBookById(int ? id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(livre => new BookModel()
                {
                    Author = livre.Author,
                    Category = livre.Category,
                    Description = livre.Description,
                    Id = livre.Id,
                    LanguageId = livre.Language.Id,
                    Language = livre.Language.Nom,
                    Title = livre.Title,
                    TotalPages = livre.TotalPages,
                    Gallery = livre.BookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL 
                    }).ToList(),
                    BookPdfUrl = livre.BookPdfUrl
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }
    }
}
