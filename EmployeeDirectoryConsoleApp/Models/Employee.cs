using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Models
{
    public class Employee
    {
        public required string EmpNo, FirstName, LastName, Email, JobTitle, Department, Location;
        public string? MobileNumber, Manager, Project;
        public DateTime DateOfBirth, JoiningDate;
        public bool isDobSet, isManager;
    }

}
