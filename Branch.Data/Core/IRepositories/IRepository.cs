using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Branch.Data.Core.IRepositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity GetById(long id);
		IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
        //void Update(TEntity dbEntity, TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void SaveChanges();
    }
}
