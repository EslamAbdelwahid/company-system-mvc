using Company.Es.DAL.Models;
using Company.Es.DAL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec);
        Task<T> GetWithSpecAsync(ISpecifications<T> spec);


        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
