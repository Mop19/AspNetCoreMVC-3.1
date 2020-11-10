using Microsoft.AspNetCore.Mvc;

namespace Mouha.DemoAspNetCoreGithub.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "Tous les livres";
        }

        public string GetBook(int id)
        {
            return $"Livre avec id = {id}";
        }

        public string SearchBook(string bookName, string authorName)
        {
            return $"Livre avec nom = {bookName} & Auteur = {authorName}";
        }
    }
}
