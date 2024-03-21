using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp
{
    internal class EmployeeMenu
    {
        EmployeeService employeeService;
        public EmployeeMenu(EmployeeService employeeService) {
            this.employeeService = employeeService;
            employeeService.AddDummyData();
        }
        public void DisplayMenu()
        {
            Console.WriteLine("\n1. Add employee\n2. Display all\n3. Display one\n4. Edit employee\n5. Delete employee\n6. Go Back");
            Console.Write("\nEnter your choice : ");
            EmployeeMethods();
        }

        public void EmployeeMethods()
        {
            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Write("Enter Valid Option : ");
                EmployeeMethods();
                return;
             }
            switch (option)
            {
                case 1:
                    employeeService.AddEmployee();
                    break;
                case 2:
                    employeeService.DisplayAll(); 
                    break;
                case 3:
                    employeeService.DisplayOne();
                    break;
                case 4:
                    employeeService.EditEmployee();
                    break;
                case 5:
                    employeeService.DeleteEmployee();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Enter Valid Option");
                    break;
            }
            DisplayMenu();
        }
    }
}
