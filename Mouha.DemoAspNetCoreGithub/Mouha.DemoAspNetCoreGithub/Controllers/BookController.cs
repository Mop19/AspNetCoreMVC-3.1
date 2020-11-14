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
            Title = "Tous les livres";
            var data = _bookRepository.GetAllBooks();

            return View(data);
        }


        public ViewResult GetBook(int id)
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book =  _bookRepository.GetBookById(id);
            data.Nom = "Mouhamed";
            //var data =
           // Title = "Détails livre" + data.Title;

            return View(data);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);  //$"Livre avec nom = {bookName} & Auteur = {authorName}";
        }
    }
}
