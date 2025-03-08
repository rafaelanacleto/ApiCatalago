using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiCatalago.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository
{
    public class Repository<t> : IRepository<t> where t : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public t Create(t entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public t? Get(Expression<Func<t, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<t> GetAll()
        {
            throw new NotImplementedException();
        }

        public t Update(t entity)
        {
            throw new NotImplementedException();
        }
    }
}