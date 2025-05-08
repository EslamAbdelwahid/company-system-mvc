using Company.Es.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.DAL.Specifications.Employees
{
    public class EmployeeSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeSpecifications() 
        {
            Includes.Add(e => e.WorkFor);
        }
        public EmployeeSpecifications(int id) : base(e => e.Id == id)
        {
            Includes.Add(e => e.WorkFor);
        }
    }
}
