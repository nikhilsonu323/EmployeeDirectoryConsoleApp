using EmployeeDirectoryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectoryConsoleApp.Repositories
{
    internal class RoleRepo
    {
        List<Role> roles = new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }
        public IEnumerable<Role> GetAll() 
        {
            return roles;
        }
    }
}
