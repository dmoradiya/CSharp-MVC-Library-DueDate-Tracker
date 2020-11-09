using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_DueDate_Tracker_With_Database.Models;
using Library_DueDate_Tracker_With_Database.Models.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace Library_DueDate_Tracker_With_Database.Controllers
{
    public class BookController : Controller
    {
        // ##################### Actions ##########################
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }        
        public IActionResult List(string filter)
        {
            if (filter == "Overdue")
            {
                ViewBag.Books = GetOverdueBooks();
                ViewBag.Filter = true;
            }
            else
            {
                ViewBag.Books = GetBooks();
                ViewBag.Filter = false;
            }
            
            return View();
        }
        public IActionResult Create(string authorID, string title, string publicationDate)
        {
            ViewBag.Authors = AuthorsController.GetAuthors();
            if (Request.Method == "POST")
            {
                 try
                {
                    CreateBook(authorID, title, publicationDate);
                    ViewBag.Message = $"Successfully added book  {title}";
                }
                catch (ValidationException e)
                {
                    ViewBag.Message = "There exist problem(s) with your submission, see below.";
                    ViewBag.Exception = e;
                    ViewBag.Error = true;
                 }
            }
               
            return View();
        }
        public IActionResult Details(string id)
        {
                ViewBag.Details = GetBookByID(id);

                ViewBag.Message = TempData["Message"];
                ViewBag.Error = TempData["Error"];

                return View();
        }
        public IActionResult Extend(string id)
        {
            try
            {
                ExtendDueDateForBookByID(id);
                TempData["Message"] = "Successfully Extended DueDate";
                TempData["Error"] = false;
            }
            catch 
            {
                TempData["Message"] = "There exist problem(s) with your submission";
                TempData["Error"] = true;

            }
            
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        public IActionResult Return(string id)
        {
            try
            {
                ReturnBookByID(id);
                TempData["Message"] = "Successfully Returned Book";
                TempData["Error"] = false;
            }
            catch
            {
                TempData["Message"] = "There exist problem(s) with your submission";
                TempData["Error"] = true;

            }
            
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
                    TempData["Message"] = "Successfully Borrowed Your Book";
                    TempData["Error"] = false;
                }
                catch 
                {

                    TempData["Message"] = "There exist problem(s) with your submission";
                    TempData["Error"] = true;
                }
            
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }
        // ################### Methods ########################
        public static List<Book> GetBooks()
        {
            List<Book> results;
           
            using (LibraryContext context = new LibraryContext())
            {
                results = context.Books
                            .Include(x=>x.Author)
                            .Include(x=>x.Borrows)
                            .ToList();
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

        public void CreateBook(string authorID, string title, string publicationDate)
        {
            int parsedAuthorID = 0;
            DateTime parsedPublicationDate = new DateTime();

            ValidationException exception = new ValidationException();
            
            // Trim all The Input Parameters
            authorID = !string.IsNullOrWhiteSpace(authorID) ? authorID.Trim() : null;
            title = !string.IsNullOrWhiteSpace(title) ? title.Trim() : null;
            publicationDate = !string.IsNullOrWhiteSpace(publicationDate) ? publicationDate.Trim() : null;




            using (LibraryContext context = new LibraryContext())
            {
                // Validation for AuthorID (No value for Author ID)
                if (string.IsNullOrWhiteSpace(authorID))
                {
                    exception.ValidationExceptions.Add(new Exception("Author ID not Provided"));
                }
                else
                {
                    // Validation for AuthorID (Author ID fails to parse)
                    if (!int.TryParse(authorID, out parsedAuthorID))
                    {
                        exception.ValidationExceptions.Add(new Exception("Auhtor ID not Valid"));
                    }
                    else
                    {
                        // Validation for AuthorID (Book exists with Author ID)
                        if (!context.Books.Any(X=>X.AuthorID == parsedAuthorID))
                        {
                            exception.ValidationExceptions.Add(new Exception("Book does not Exist"));
                        }
                       

                    }
                }

                // Validation for Title (No value for Title)
                if (string.IsNullOrWhiteSpace(title))
                {
                    exception.ValidationExceptions.Add(new Exception("Book Title not Provided"));
                }
                else
                {
                    // Validation for Title (Check for Duplicate Title)
                    if (context.Books.Any(x=>x.Title.ToUpper() == title.ToUpper()))
                    {
                        exception.ValidationExceptions.Add(new Exception("Book Title already Exist"));
                    }
                    else
                    {
                        // Validation for Title (Check title's lenght)
                        if (title.Length > 50)
                        {
                            exception.ValidationExceptions.Add(new Exception("maximux lenght of Book Title is 50 characters"));
                        }

                    }
                }

                // Validation for publication Date (No value for publicationDate)
                if (string.IsNullOrWhiteSpace(publicationDate))
                {
                    exception.ValidationExceptions.Add(new Exception("publication Date not Provided"));
                }
                else
                {
                    // Validation for publication (publicationDate fails to parse)
                    if (!DateTime.TryParse(publicationDate, out parsedPublicationDate))
                    {
                        exception.ValidationExceptions.Add(new Exception("Publication Date not Valid"));
                    }
                    else
                    {
                        if (parsedPublicationDate > DateTime.Today)
                        {
                            exception.ValidationExceptions.Add(new Exception("Publication Date Can not be Future Date"));
                        }
                    }
                   
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }


                context.Books.Add(new Book()
                {
                    Title = title,
                    AuthorID = parsedAuthorID,
                    PublicationDate = parsedPublicationDate
                });
                context.SaveChanges();
            }
        }
        
        public static List<Book> GetOverdueBooks()
        {
            List<Book> results;
                results = GetBooks()
                            .Where(x => x.Borrows.LastOrDefault().DueDate < DateTime.Today)
                            .ToList();
            return results;
        }

    }
}
