using Company.Es.BLL.Interfaces;
using Company.Es.DAL.Data.Contexts;
using Company.Es.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL.Repos
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {

        public EmployeeRepo(AppDbContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<Employee>> SearchByNameAsync(string name)
        {
            return await context.Employees.Where(e => e.Name.ToLower().Contains(name.ToLower()))
            .Include(e => e.WorkFor).ToListAsync();
        }
    }
}
