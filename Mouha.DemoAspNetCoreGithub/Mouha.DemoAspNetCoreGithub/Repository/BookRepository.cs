using Mouha.DemoAspNetCoreGithub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Repository
{
    public class BookRepository
    {
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
                new BookModel(){Id=1, Title="MVC", Author="ETienne", Description= "Ceci est la description du livre MVC"},
                new BookModel(){Id=2, Title="MVVM", Author="Mouha", Description= "Ceci est la description du livre MVVM"},
                new BookModel(){Id=3, Title="C#", Author="Joseph", Description = "Ceci est la description du livre C#" },
                new BookModel(){Id=4, Title="JAVA", Author="Lisa", Description = "Ceci est la description du livre JAVA"},  
                new BookModel(){Id=5, Title="PHP", Author="Belanger", Description = "Ceci est la description du livre PHP"},
                new BookModel(){Id=6, Title="AZURE DEVOPS", Author="Mouhamed", Description = "Ceci est la description du livre AZURE DEVOPS"}
            };
        }
    }
}
