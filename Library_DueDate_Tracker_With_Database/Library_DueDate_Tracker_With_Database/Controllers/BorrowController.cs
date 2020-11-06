using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DueDate_Tracker_With_Database.Controllers
{
    public class BorrowController : Controller
    {
        // ################# Actions #########################
        public IActionResult Index()
        {
            return View();
        }

        // #################### Methods ####################


        public static void ExtendDueDateForBorrowByID(string id)
        {
            Borrow found;
            using (LibraryContext context = new LibraryContext())
            {
                found = context.Borrows.Where(x=>x.BookID == int.Parse(id)).SingleOrDefault();
                found.DueDate = DateTime.Today.AddDays(7);
                context.SaveChanges();
            }
            
        }

        public static void ReturnBorrowByID(string id)
        {
            Borrow found;
            using (LibraryContext context = new LibraryContext())
            {
                found = context.Borrows.Where(x => x.BookID == int.Parse(id)).SingleOrDefault();
                found.ReturnedDate = DateTime.Today;
                context.SaveChanges();
            }

        }
        public static void CreateBorrow(string id)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Borrows.Add(new Borrow()
                {
                    BookID = int.Parse(id),
                    ChechedOutDate = DateTime.Today,
                    DueDate = DateTime.Today.AddDays(14),
                    ReturnedDate = null,

                });
                context.SaveChanges();
            }

        }

    }
}
