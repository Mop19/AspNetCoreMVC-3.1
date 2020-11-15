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
        public int AjouterNouveauLivre(BookModel model)
        {
            var nouveauLivre = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            _context.Books.Add(nouveauLivre);
            _context.SaveChanges();

            return nouveauLivre.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int ? id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="ETienne", Description= "Ceci est la description du livre MVC", Category="Programming", Language="English", TotalPages=134},
                new BookModel(){Id=2, Title="MVVM", Author="Mouha", Description= "Ceci est la description du livre MVVM", Category="Framework", Language="Chinese", TotalPages=567},
                new BookModel(){Id=3, Title="C#", Author="Joseph", Description = "Ceci est la description du livre C#" , Category="Developer", Language="Hindi", TotalPages=897},
                new BookModel(){Id=4, Title="JAVA", Author="Lisa", Description = "Ceci est la description du livre JAVA", Category="Concept", Language="English", TotalPages=564},  
                new BookModel(){Id=5, Title="PHP", Author="Belanger", Description = "Ceci est la description du livre PHP", Category="Programming", Language="English", TotalPages=100},
                new BookModel(){Id=6, Title="AZURE DEVOPS", Author="Mouhamed", Description = "Ceci est la description du livre AZURE DEVOPS", Category="DevOps", Language="English", TotalPages=800}
            };
        }
    }
}
