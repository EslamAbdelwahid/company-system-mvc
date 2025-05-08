using Company.Es.BLL.Interfaces;
using Company.Es.DAL.Data.Contexts;
using Company.Es.DAL.Models;
using Company.Es.DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.BLL.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected private readonly AppDbContext context;

        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }


        public void Update(T entity)
        {
            context.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }
    }
}
