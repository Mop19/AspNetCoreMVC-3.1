using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    //[Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository, 
                              LanguageRepository languageRepository,
                              IWebHostEnvironment webHostEnvironment) //Dependence injection
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        //[Route("~/tousleslivvres")]
        public async Task<ViewResult> GetAllBooks()
        {          
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        [Route("~/livre-detail/{id:int:min(1)}", Name = "livreDetailRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);

            return View(data);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);  //$"Livre avec nom = {bookName} & Auteur = {authorName}";
        }
        [HttpGet]
        public async Task<ViewResult>  AjoutNouveauLivre(bool estSucces, int livreId = 0)
        {
            var model = new BookModel()
            {
               // Language = "2"
            };

            ViewBag.Langage = new SelectList(await _languageRepository.GetLanguages(), "Id", "Nom");

            ViewBag.EstSucces = estSucces;
            ViewBag.LivreId = livreId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>  AjoutNouveauLivre(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string dossier = "books/cover/";
                    bookModel.CoverImageUrl = await UploadImage(dossier, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string dossier = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(dossier, file)
                        };
                        bookModel.Gallery.Add(gallery);  
                    }  
                }

                if (bookModel.BookPdf != null)
                {
                    string dossier = "books/cover/";
                    bookModel.BookPdfUrl = await UploadImage(dossier, bookModel.BookPdf);
                }

                int id = await _bookRepository.AjouterNouveauLivre(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AjoutNouveauLivre), new { estSucces = true, livreId = id });
                }
            }

            ViewBag.Langage = new SelectList(await _languageRepository.GetLanguages(), "Id", "Nom");

            return View();
        }

        private async Task<string> UploadImage(string cheminDossier, IFormFile file)
        {

            cheminDossier += Guid.NewGuid().ToString() + "_" + file.FileName;

            string dossierServer = Path.Combine(_webHostEnvironment.WebRootPath, cheminDossier);

            await file.CopyToAsync(new FileStream(dossierServer, FileMode.Create));

            return "/" + cheminDossier;
        }

    }
}
