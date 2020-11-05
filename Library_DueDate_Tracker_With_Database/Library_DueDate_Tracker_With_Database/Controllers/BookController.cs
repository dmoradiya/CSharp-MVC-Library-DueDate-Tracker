using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DueDate_Tracker_With_Database.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        
        public IActionResult List()
        {
            ViewBag.Book = GetBooks();
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Author = AuthorsController.GetAuthors();
            return View();
        }
        public IActionResult Details(string id)
        {
            ViewBag.Details = GetBookByID(id);

            return View();
        }
        public IActionResult BorrowBook(string bookId)
        {
            ViewBag.BorrowBook = BorrowController.GetBorrowBooks().Where(x=>x.BookID == int.Parse(bookId)).SingleOrDefault();

            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", bookId } });
        }
        // Methods
        public static List<Book> GetBooks()
        {
            List<Book> results;
           
            using (LibraryContext context = new LibraryContext())
            {
                results = context.Books.Include(x=>x.Author).Include(x=>x.Borrows).ToList();
            }
            return results;
        }
        public Book GetBookByID(string id)
        {
            return GetBooks().Where(x => x.ID == int.Parse(id)).Single();
        }

        //public void ExtendDueDateByID(string id)
        //{
        //    GetBookByID(id).DueDate = GetBookByID(id).DueDate.AddDays(7);
        //}

        //public void ReturnBookByID(string id)
        //{
        //    GetBookByID(id).ReturnedDate = DateTime.Today;
        //}

        //public void DeleteBookByID(string id)
        //{
        //    Books.Remove(GetBookByID(id));
        //}

    }
}
