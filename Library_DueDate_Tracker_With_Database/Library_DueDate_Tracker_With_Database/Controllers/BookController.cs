using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.Book = GetAuthors();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public static List<Book> GetAuthors()
        {
            List<Book> results;
            using (LibraryContext context = new LibraryContext())
            {
                results = context.Books.Include(x=>x.Author).ToList();

            }
            return results;
        }
    }
}
