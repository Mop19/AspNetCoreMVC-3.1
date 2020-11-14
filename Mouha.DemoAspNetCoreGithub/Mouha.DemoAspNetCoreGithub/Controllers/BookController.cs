using Microsoft.AspNetCore.Mvc;
using Mouha.DemoAspNetCoreGithub.Models;
using Mouha.DemoAspNetCoreGithub.Repository;
using System.Collections.Generic;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        [ViewData]
        public string Title { get; set; }

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {          
            var data = _bookRepository.GetAllBooks();

            return View(data);
        }

        //[Route("livre-detail/{id}", Name = "livreDetailRoute")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);

            return View(data);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);  //$"Livre avec nom = {bookName} & Auteur = {authorName}";
        }
    }
}
