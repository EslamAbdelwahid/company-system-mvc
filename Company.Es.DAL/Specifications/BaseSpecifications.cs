using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.Es.DAL.Specifications
{
    public class BaseSpecifications<TEntity> : ISpecifications<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public BaseSpecifications(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }
        public BaseSpecifications()
        {
            
        }
    }
}
