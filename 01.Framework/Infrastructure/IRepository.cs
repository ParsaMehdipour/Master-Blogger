using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _01.Framework.Domain;

namespace _01.Framework.Infrastructure
{
    public interface IRepository<in TKey,TEntity> where TEntity : BaseDomain<TKey>
    {
        TEntity Get(TKey id); // ==> Article Get(long id)
        List<TEntity> GetAll(); // ==> List<Article> GetAll()
        void Create(TEntity entity); // ==> Void Create(Article article)
        bool Exists(Expression<Func<TEntity, bool>> expression); // ==> bool Exists(x => x.Title == title)
    }
}
