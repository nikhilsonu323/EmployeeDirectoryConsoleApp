using EmployeeDirectoryConsoleApp.Models;
using EmployeeDirectoryConsoleApp.Repositories;

namespace EmployeeDirectoryConsoleApp
{
    internal class EmployeeService
    {
        EmployeeRepo _employeeRepo;
        public EmployeeService(EmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public void AddDummyData()
        {
            var employee = new Employee { EmpNo = "TZ0000", FirstName = "Luffy", LastName = "Monkey D", Email = "luffy@strawhats.com", JobTitle = "jobTitle", Location = "East blue", Department = "Pirate", MobileNumber = "0987654321", Manager = "", Project = "One piece", isDobSet = false, isManager = true, JoiningDate = DateTime.Now };
            _employeeRepo.Add(employee);
            employee = new Employee { EmpNo = "TZ0001", FirstName = "Roronora", LastName = "Zoro", Email = "zoro@strawhats.com", JobTitle = "swordsman", Location = "East blue", Department = "Pirate", MobileNumber = "0987654322", Manager = "TZ0000", Project = "One piece", isDobSet = false, isManager = false, JoiningDate = DateTime.Now };
            _employeeRepo.Add(employee);
            employee = new Employee { EmpNo = "TZ0002", FirstName = "Prince", LastName = "Sanji", Email = "sanji@strawhats.com", JobTitle = "cook", Location = "North blue", Department = "Pirate", MobileNumber = "0987654323", Manager = "TZ0000", Project = "One piece", isDobSet = false, isManager = false, JoiningDate = DateTime.Now };
            _employeeRepo.Add(employee);
        }
        public void AddEmployee()
        {
            string empNo, firstName, lastName, email, jobTitle, department, mobileNumber, manager, project, location;
            DateTime dateOfBirth, joiningDate;
            bool isDobSet = false;
            empNo = TakeInput("Enter employee Number", Validations.isEmpnoValid);
            firstName = TakeInput("Enter First Name", Validations.isNameValid);
            lastName = TakeInput("Enter Last Name", Validations.isNameValid);
            email = TakeInput("Enter email", Validations.isEmailValid);
            mobileNumber = TakeInput("Enter Mobile Number", Validations.isMobileNumberValid);
            location = TakeInput("Enter Location", Validations.isNotEmpty);
            jobTitle = TakeInput("Enter Job Title", Validations.isNotEmpty);
            department = SelectFromList("Select Department", true, StaticData.Departments);
            manager = SelectFromList("Select Manager", false, _employeeRepo.GetAllManagers());
            project = SelectFromList("Select Project", false, StaticData.Projects);
            string dobDateString = TakeInput("Enter Date of birth", Validations.isDOBValid);
            if (dobDateString.Length != 0)
            {
                dateOfBirth = DateTime.ParseExact(dobDateString, "d/M/yyyy", null);
                isDobSet = true;
            }
            joiningDate = DateTime.ParseExact(TakeInput("Enter JoiningDate", Validations.isDOBValid), "d/M/yyyy", null);
            var employee = new Employee { EmpNo = empNo, FirstName = firstName, LastName = lastName, Email = email, JobTitle = jobTitle, Location = location, Department = department, MobileNumber = mobileNumber, Manager = manager, Project = project, isDobSet = isDobSet, isManager = false };
            _employeeRepo.Add(employee);
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
                if (input.Length == 0 && !isRequired) { return ""; }
                if (int.TryParse(input, out index) == false || index > list.Count)
                {
                    Console.Write("Enter valid option : ");
                }
                else { return list[index-1]; }
            }
        }
        public string TakeInput(string message, Predicate<string> validator)
        {
            string input;
            Console.Write(message + " : ");
            while (true)
            {
                /*input = (Console.ReadLine() ?? "").Trim();*/
                input = Console.ReadLine() ?? "";
                input = input.Trim();
                if (validator(input))
                {
                    return input;
                }
            }
        }
        public void DisplayAll()
        {
            var employees = _employeeRepo.GetAll();
            if (!employees.Any())
            {
                Console.WriteLine("No employees exist here");
                return;
            }
            foreach (Employee emp in employees)
            {
                string fullName = emp.FirstName + " " + emp.LastName;
                string joiningDate = emp.JoiningDate.ToShortDateString();
                string manager = (emp.Manager == null || emp.Manager == "")  ? "No Manager" : emp.Manager;
                /*Console.WriteLine("\nEmp No : " + emp.EmpNo);
                Console.WriteLine($"Full Name : {emp.FirstName} {emp.LastName}");
                Console.WriteLine("Role : " + emp.JobTitle);
                Console.WriteLine("Department : " + emp.Department);
                Console.WriteLine("Location : " + emp.Location);
                Console.WriteLine("Joining Date : " + emp.JoiningDate);
                Console.WriteLine("Manager Name : " + emp.Manager);
                Console.WriteLine("Project Name : " + emp.Project);
                Console.WriteLine("Mobile Number : " + emp.MobileNumber);*/
                Console.WriteLine($"{emp.EmpNo.PadRight(7)} | {fullName.PadRight(15)} | {emp.JobTitle.PadRight(10)} | {emp.Department.PadRight(10)} | {emp.Location.PadRight(15)} | {joiningDate.PadRight(10)} | {manager.PadRight(10)} | {emp.Project.PadRight(12)} | {emp.MobileNumber.PadRight(14)} |");
            }
        }
        public void DisplayOne()
        {
            Console.Write("Enter Employee Number of Employee : ");
            string empNo = Console.ReadLine() ?? "";
            Employee? emp = _employeeRepo.GetById(empNo);
            if (emp == null)
            {
                Console.WriteLine("Employee with this Id doesn't exist");
            }
            else
            {
                Console.WriteLine("\nEmp No : " + emp.EmpNo);
                Console.WriteLine($"Full Name : {emp.FirstName} {emp.LastName}");
                Console.WriteLine("Date of Birth : " + emp.DateOfBirth);
                Console.WriteLine("Email : " + emp.Email);
                Console.WriteLine("Mobile Number : " + emp.MobileNumber);
                Console.WriteLine("Joining Date : " + emp.JoiningDate);
                Console.WriteLine("Location : " + emp.Location);
                Console.WriteLine("Role : " + emp.JobTitle);
                Console.WriteLine("Department : " + emp.Department);
                Console.WriteLine("Manager Name : " + emp.Manager);
                Console.WriteLine("Project Name : " + emp.Project);
            }
        }
        public void EditEmployee()
        {
            Console.Write("Enter Employee Number of Employee : ");
            string empNo = Console.ReadLine() ?? "";
            Employee? emp = _employeeRepo.GetById(empNo);
            if(emp  == null) {
                Console.WriteLine("Employee with this id id doesn't exist");
                return;
            }
            Console.WriteLine("\n1.First Name  2.LastName 3.Date of birth  4.Email  5.MobileNumber  6.Location  7.Role  8.Department  9.Manager  10.Project  11.Back");
            while (true)
            {
                Console.Write("\nSelect option to edit value : ");
                int option;
                if (int.TryParse(Console.ReadLine(),out option))
                {
                    switch(option) 
                    {
                        case 1: 
                            emp.FirstName = TakeInput("Enter First Name", Validations.isNameValid);
                            break;
                        case 2: 
                            emp.LastName = TakeInput("Enter Last Name", Validations.isNameValid);
                            break;
                        case 3:
                            string dobDateString = TakeInput("Enter Date of birth", Validations.isDOBValid);
                            if (dobDateString.Length != 0)
                            {
                                emp.DateOfBirth = DateTime.ParseExact(dobDateString, "d/M/yyyy", null);
                                emp.isDobSet = true;
                            }
                            break;
                        case 4:
                            emp.Email = TakeInput("Enter email", Validations.isEmailValid);
                            break;
                        case 5:
                            emp.MobileNumber = TakeInput("Enter Mobile Number", Validations.isMobileNumberValid);
                            break;
                        case 6:
                            emp.Location = TakeInput("Enter Location", Validations.isNotEmpty);
                            break;
                        case 7:
                            emp.JobTitle = TakeInput("Enter Job Title", Validations.isNotEmpty);
                            break;
                        case 8:
                            emp.Department = SelectFromList("Select Department", false, StaticData.Departments);
                            break;
                        case 9:
                            emp.Manager = SelectFromList("Select Manager", false, _employeeRepo.GetAllManagers());
                            break;
                        case 10:
                            emp.Project = SelectFromList("Enter Project Name", false, StaticData.Projects);
                            break;
                        case 11: return;
                        default:
                            Console.Write("Invalid Choice");
                            break;
                    }
                }
                else
                    Console.Write("Enter valid choice : ");
            }
        }
        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Number of Employee to be deleted : ");
            string empNo = Console.ReadLine() ?? "";
            if (_employeeRepo.RemoveById(empNo))
            {
                Console.WriteLine("Employee Removed sucessfully");
            }
            else
            {
                Console.WriteLine("Employee with this Id doesn't exist");
            }
        }
    }
}
