﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_DueDate_Tracker_With_Database.Models.Exceptions
{
    public class ValidationException : Exception
    {
        // Common Types of Validation:
        /*
            ✅ 1) Trim all the whitespace off of text inputs before further processing.
            ✅ 2) Comparisons should be case insensitive (unless business rules dictate otherwise.
            ✅ 3) String inputs should be size capped at their database size.
            ✅ 4) NOT NULL fields should not permit whitespace / empty values.
                ✅ 4a) NULL fields should treat whitespace as NULL.
            ✅ 5) All numeric fields should succesfully parse to their data type (int, double, etc).
                ✅ 5a) Keep in mind the max/min sizes of certain numeric types.
            6) Any time we are using a "GetByID" method, we should make sure the ID exists.
            ✅ 7) Any foreign key field should be checked to ensure the referenced record exists.
        */


        public List<Exception> ValidationExceptions { get; set; }

        public ValidationException() : base("Please view ValidationExceptions for details.")
        {
            ValidationExceptions = new List<Exception>();
        }

        public ValidationException(string message) : base("Please view ValidationExceptions for details.")
        {
            ValidationExceptions = new List<Exception>()
            {
                new Exception(message)
            };
        }
    }
}
