using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _01.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01.Framework.Infrastructure
{
    public class BaseRepository<TKey,TEntity> : IRepository<TKey,TEntity> where TEntity : BaseDomain<TKey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public TEntity Get(TKey id)
        {
            return _context.Find<TEntity>(id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Create(TEntity entity)
        {
            _context.Add<TEntity>(entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Any(expression);
        }
    }
}
