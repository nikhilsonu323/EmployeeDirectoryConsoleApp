using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectoryConsoleApp.Models;

namespace EmployeeDirectoryConsoleApp.Repositories
{
    internal class EmployeeRepo
    {
        List<Employee> employees = new List<Employee>();
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public bool RemoveById(string id)
        {
            Employee? employee = GetById(id);
            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }
        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }
        /*        public bool TryGetById(string id,out Employee? employee) 
                {
                    IEnumerable<Employee> employeeEnumerator = from emp in employees where emp.EmpNo == id select emp;
                    employee = null;
                    if (employeeEnumerator != null) {
                        employee = employeeEnumerator.ElementAt(0);    
                        return true;
                    }
                    return false;
                }*/

        public Employee? GetById(string id)
        {
            return employees.FirstOrDefault(emp => emp.EmpNo == id);
        }
        public bool hasId(string id)
        {
            var employee = from emp in employees where emp.EmpNo == id select emp;
            if (employee != null) { return true; }
            return false;
        }

        public List<string> GetAllManagers()
        {
            List<string> managers = new List<string>();
            foreach (Employee emp in employees)
            {
                managers.Add(emp.EmpNo);
            }
            return managers;
        }
    }
}
