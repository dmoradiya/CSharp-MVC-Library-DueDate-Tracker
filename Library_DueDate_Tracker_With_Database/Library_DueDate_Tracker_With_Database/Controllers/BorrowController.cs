using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.AspNetCore.Mvc;
/*
    Add a “ExtendDueDateForBorrowByID()” method that will extend the “DueDate” by 7 days from today.
    Add a “ReturnBorrowByID()” method that will set the “Borrow”s “ReturnedDate” to today.
    Add a “CreateBorrow()” method that will accept a “Book.ID” as a parameter and create a borrow for it.
    The “CheckOutDate” will be today.
    The “DueDate” will be 14 days from today.
    The “ReturnedDate” will be null.

 */
namespace Library_DueDate_Tracker_With_Database.Controllers
{
    public class BorrowController : Controller
    {
        // Actions
        public IActionResult Index()
        {
            return View();
        }

        // Methods
        public void ExtendDueDateForBorrowByID()
        {
            using (LibraryContext context = new LibraryContext())
            {
                
            }
            
        }
    }
}
