using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DueDate_Tracker_With_Database.Controllers
{
    public class BookController : Controller
    {
        // ##################### Actions ##########################
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }        
        public IActionResult List()
        {
            ViewBag.Books = GetBooks();
            return View();
        }
        public IActionResult Create(string author, string title, string publicationDate)
        {
            ViewBag.Authors = AuthorsController.GetAuthors();

            if (author != null && title != null && publicationDate != null)
            {
                try
                {
                    CreateBook(author, title, publicationDate);

                    ViewBag.SuccessfulCreation = true;
                    ViewBag.Status = $"Successfully added book  {title}";
                }
                catch (Exception e)
                {

                    ViewBag.SuccessfulCreation = false;
                    ViewBag.Status = $"An error occured. {e.Message}";
                }
            }
            return View();
        }
        public IActionResult Details(string id)
        {
            ViewBag.Details = GetBookByID(id);

            return View();
        }
        public IActionResult Extend(string id)
        {
            ExtendDueDateForBookByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        public IActionResult Return(string id)
        {
            ReturnBookByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        public IActionResult Delete(string id)
        {
            DeleteBookByID(id);
            return RedirectToAction("List");
        }
        
        public IActionResult BorrowBook(string id)
        {
            try
            {
                BorrowController.CreateBorrow(id);
                ViewBag.Status = true;
                ViewBag.Message = "Successfully Borrowed Your Book";
            }
            catch (Exception)
            {

                ViewBag.Status = false;
                ViewBag.Message = "Error";
            }

            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        // ################### Methods ########################
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
            return GetBooks().Where(x => x.ID == int.Parse(id)).SingleOrDefault();
        }

        public void ExtendDueDateForBookByID(string id)
        {
            BorrowController.ExtendDueDateForBorrowByID(id);
        }

        public void ReturnBookByID(string id)
        {
            BorrowController.ReturnBorrowByID(id);
        }

        public void DeleteBookByID(string id)
        {
            
            using (LibraryContext context = new LibraryContext())
            {

                context.Books.Remove(GetBookByID(id));
                context.SaveChanges();
            }
            
        }

        public void CreateBook(string author, string title, string publicationDate)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Add(new Book()
                {
                    Title = title,
                    AuthorID = int.Parse(author),
                    PublicationDate = DateTime.Parse(publicationDate)
                });
                context.SaveChanges();
            }
        }
        public void GetOverdueBooks()
        {
            
                GetBooks().Where(x => x.Borrows.LastOrDefault().DueDate > DateTime.Today);
        }

    }
}
