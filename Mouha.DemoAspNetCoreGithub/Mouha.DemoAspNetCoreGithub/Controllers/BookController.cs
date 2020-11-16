using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository) ////Dependence injection
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {          
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        //[Route("livre-detail/{id}", Name = "livreDetailRoute")]
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
                int id = await _bookRepository.AjouterNouveauLivre(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AjoutNouveauLivre), new { estSucces = true, livreId = id });
                }
            }

            ViewBag.Langage = new SelectList(await _languageRepository.GetLanguages(), "Id", "Nom");

            return View();
        }

     
    }
}
