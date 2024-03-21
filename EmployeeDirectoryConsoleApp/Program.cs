using EmployeeDirectoryConsoleApp;
using EmployeeDirectoryConsoleApp.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        EmployeeMenu _employeeMenu = new EmployeeMenu(new EmployeeService(new EmployeeRepo()));
        RoleServices _roleServices = new RoleServices(new RoleRepo());
        while (true)
        {
            Console.WriteLine("\n1. Employee Management\n2. Role Management\n3. Exit\n");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1: 
                    _employeeMenu.DisplayMenu();
                    break;
                case 2:
                    _roleServices.DisplayMenu();
                    break;
                case 3: 
                    return;
                default : 
                    Console.WriteLine("Enter Valid choice");
                    break;
            }
        }
    }
}