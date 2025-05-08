using Company.Es.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL.Interfaces
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        //IEnumerable<Employee> GetAll();
        //Employee Get(int? id);

        //int Add(Employee entity);
        //int Update(Employee entity);
        //int Delete(Employee entity);
        public Task<IEnumerable<Employee>> SearchByNameAsync(string name);
    }
}
