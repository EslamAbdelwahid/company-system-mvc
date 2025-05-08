using Company.Es.BLL.Interfaces;
using Company.Es.DAL.Data.Contexts;
using Company.Es.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL.Repos
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(AppDbContext context) : base(context)
        {

        }
    }
}
