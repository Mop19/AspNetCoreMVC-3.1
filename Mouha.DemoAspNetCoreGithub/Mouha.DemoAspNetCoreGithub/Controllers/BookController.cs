using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository) ////Dependence injection
        {
            _bookRepository = bookRepository;
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
        public ViewResult AjoutNouveauLivre(bool estSucces, int livreId = 0)
        {
            var model = new BookModel()
            {
                Language = "Français"
            };

            ViewBag.Langage = new SelectList(new List<string>() { "Français", "Anglais", "Wolof" });

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

            ViewBag.Langage = new SelectList(new List<string>() { "Français", "Anglais", "Wolof" });
            ModelState.AddModelError("", "Ceci est un première message d'erreur client");
            ModelState.AddModelError("", "Ceci est un second message d'erreur client");

            return View();
        }
    }
}
