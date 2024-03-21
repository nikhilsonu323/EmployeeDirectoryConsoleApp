using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EmployeeDirectoryConsoleApp
{
    internal class Validations
    {
        public static bool isEmpnoValid(string EmpNo)
        {
            string pattern = @"^TZ[0-9]{4}$";
            Regex regex = new Regex(pattern);
            if(EmpNo == "")
            {
                Console.Write("Emp No is required : ");
                return false;
            }
            if (!regex.IsMatch(EmpNo))
            {
                Console.Write("Enter valid employee Number (TZ0000)");
                return false ;
            }
            return true;
        }
        public static bool isNameValid(string Name)
        {
            string pattern = @"^[a-zA-Z]+$";
            if (Name == "")
            {
                Console.Write("Name is required : ");
                return false;
            }
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(Name))
            {
                Console.Write("Enter Valid Name : ");
                return false;
            }
            return true;
        }
        public static bool isEmailValid(string Email)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z0-9._-]*@[a-zA-Z0-9]+[.][a-zA-Z]+$";
            if (Email == "")
            {
                Console.Write("Email is required : ");
                return false;
            }
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(Email))
            {
                Console.Write("Enter Valid Email : ");
                return false;
            }
            return true;
        }
        public static bool isMobileNumberValid(string input)
        {
            /*string pattern = @"(\+[0-9]{1,3}[ -])?[0-9]{10}";*/
            string pattern = @"[0-9]{10}";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(input))
            {
                Console.WriteLine("Invalid Email");
                return false;
            }
            return true;
        }
        public static bool isDOBValid(string input)
        {
            DateTime dob;
            if(!DateTime.TryParseExact(input,"d/M/yyyy",null,System.Globalization.DateTimeStyles.None, out dob))
            {
                Console.Write("Invalid Date Format : ");
                return false;
            }
/*            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            if (age >= 18) 
            {
                Console.Write("Employee should be of minimum 18 years old : ");
            }*/
            return true;
        }
        public static bool isJoiningDateValid(string input)
        {
            DateTime joiningDate;
            if(!DateTime.TryParseExact(input,"d/M/yyyy",null,System.Globalization.DateTimeStyles.None, out joiningDate))
            {
                Console.Write("Invalid Date Format : ");
                return false;
            }
            if (joiningDate > DateTime.Now)
            {
                Console.Write("Joining shouldn't be greather then today : ");
            }
            return true;
        }
        public static bool isNotEmpty(string input)
        {
            if(input.Length == 0)
            {
                Console.Write("This fiels is required : ");
                return false;
            }
            return true;
        }
    }
}
