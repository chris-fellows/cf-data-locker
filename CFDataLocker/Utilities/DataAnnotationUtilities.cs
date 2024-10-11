using CFDataLocker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFDataLocker.Utilities
{
    internal class DataAnnotationUtilities
    {
        public static List<string> GetValidationErrors<T>(T item)
        {            
            var context = new ValidationContext(item, serviceProvider: null, items: null);
            var errorResults = new List<ValidationResult>();

            //Perform validation
            var isValid = Validator.TryValidateObject(item, context, errorResults, true);

            Console.WriteLine("Object is: {0}", isValid ? "Valid" : "Not-Valid");
            
            foreach(var error in errorResults)
            {
                int xxx = 1000;
            }

            //Select all error messages (Messages with Member Name)
            IEnumerable<string> errorMessages = errorResults?.Select(x => x.ToString());

            //Select all error messages (Only messages)
            //IEnumerable<string> errorMessages = errorResults?.Select(x => x.ErrorMessage);
            //Print all error messages separate by semi-colon
            Console.WriteLine(string.Join("; ", errorMessages));

            return errorMessages.ToList();
        }

        /// <summary>
        /// Returns validation errors as PropertyMessage list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<PropertyMessage> GetValidationErrorsPropertyMessages<T>(T item)
        {
            var context = new ValidationContext(item, serviceProvider: null, items: null);
            var errorResults = new List<ValidationResult>();

            //Perform validation
            var isValid = Validator.TryValidateObject(item, context, errorResults, true);

            Console.WriteLine("Object is: {0}", isValid ? "Valid" : "Not-Valid");

            var propertyMessages = new List<PropertyMessage>();
            foreach (var error in errorResults.Where(e => e.MemberNames != null))
            {
                foreach(var member in error.MemberNames)
                {
                    var propertyMessage = new PropertyMessage(member, error.ErrorMessage);
                    propertyMessages.Add(propertyMessage);
                }
            }
            
            return propertyMessages;
        }
    }
}
