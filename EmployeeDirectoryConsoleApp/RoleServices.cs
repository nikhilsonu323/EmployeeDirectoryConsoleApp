using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp
{
    internal class RoleServices
    {
        RoleRepo _roleRepo;
        public RoleServices(RoleRepo roleRepo) {
            _roleRepo = roleRepo;
            AddDummyData();
        }
        public void AddDummyData()
        {
            Role role = new Role() { RoleName = "Ship wright", Department = "Product Engg.", Location = "Grand line", Description = "Repairs and Builds new Ships" };
            _roleRepo.Add(role);
            role = new Role() { RoleName = "Navigator", Department = "IT", Location = "Grand line", Description = "Naviagates at all locations" };
            _roleRepo.Add(role);
            role = new Role() { RoleName = "Swordsman", Department = "Product Engg.", Location = "Grand line", Description = "" };
            _roleRepo.Add(role);
        }
        public void DisplayMenu()
        {
            Console.WriteLine("\n1. Add Role\n2. Display all\n3. Go Back");
            Console.Write("\nEnter your choice : ");
            RoleMethods();
        }

        public void RoleMethods()
        {
            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Write("Enter Valid Option : ");
                RoleMethods();
                return;
            }
            switch (option)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    DisplayAll();
                    break;
                case 3:
                    return;
                default:
                    Console.Write("Enter Valid Option : ");
                    RoleMethods();
                    return;
            }
            DisplayMenu();
        }

        public void AddEmployee()
        {
            string roleName, department, location, description;
            roleName = TakeInput("Enter Role Name", Validations.isNotEmpty);
            department = SelectFromList("Select Department", true, StaticData.Departments);
            location = TakeInput("Enter Location", Validations.isNotEmpty);
            description = TakeInput("Enter Role Description", null);
            Role role = new Role() { RoleName = roleName, Department = department, Location = location, Description = description };
            _roleRepo.Add(role);
        }
        public string SelectFromList(string message, bool isRequired, List<string> list)
        {
            string input;
            int index;
            if (list.Count == 0) return "";
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i]}");
            }
            Console.Write(message + " : ");
            while (true)
            {
                input = Console.ReadLine() ?? "";
                input = input.Trim();
                if (input.Length == 0 && !isRequired) { return input; }
                if (int.TryParse(input, out index) == false || index > list.Count)
                {
                    Console.Write("Enter valid option : ");
                }
                else { return list[index - 1]; }
            }
        }
        public string TakeInput(string message, Predicate<string>? validator)
        {
            string input;
            Console.Write(message + " : ");
            while (true)
            {
                /*input = (Console.ReadLine() ?? "").Trim();*/
                input = Console.ReadLine() ?? "";
                input = input.Trim();
                if (validator == null || validator(input))
                {
                    return input;
                }
            }
        }

        public void DisplayAll()
        {
            var roles = _roleRepo.GetAll();
            if(!roles.Any())
            {
                Console.WriteLine("There aren't any roles currently");
                return;
            }
            string seperator = ": ";
            int width = 18;
            foreach (var role in roles)
            {
                Console.WriteLine("\n"+"Role Name".PadRight(width) + seperator + role.RoleName);
                Console.WriteLine("Department Name".PadRight(width) + seperator + role.Department);
                Console.WriteLine("Location Name".PadRight(width) + seperator + role.Location);
                Console.WriteLine("Description Name".PadRight(width) + seperator + (role.Description == "" ? "No Description about this role" : role.Description));
            }
        }
    }
}
