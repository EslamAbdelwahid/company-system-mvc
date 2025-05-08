using Company.Es.BLL.Interfaces;
using Company.Es.BLL.Repos;
using Company.Es.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEmployeeRepo _employeeRepo;
        private IDepartmentRepo _departmentRepo;
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            _employeeRepo = new EmployeeRepo(context);
            _departmentRepo = new DepartmentRepo(context);
            this.context = context;
        }
        public IEmployeeRepo EmployeeRepo => _employeeRepo;

        public IDepartmentRepo DepartmentRepo => _departmentRepo;
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
