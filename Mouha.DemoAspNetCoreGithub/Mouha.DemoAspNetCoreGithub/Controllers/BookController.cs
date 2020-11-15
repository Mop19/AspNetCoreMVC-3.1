using Microsoft.AspNetCore.Mvc;
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

        public ViewResult AjoutNouveauLivre(bool estSucces, int livreId = 0)
        {
            ViewBag.EstSucces = estSucces;
            ViewBag.LivreId = livreId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  AjoutNouveauLivre(BookModel bookModel)
        {
            int id = await _bookRepository.AjouterNouveauLivre(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AjoutNouveauLivre), new { estSucces = true, livreId = id });
            }
            return View();
        }
    }
}
