using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp
{
    internal static class StaticData
    {
        public static List<string> Departments { get; } = ["UIUX", "IT", "Product Engg."];
        public static List<string> Projects { get; } = ["Task1", "Task2", "Task3"];
    }
}
