using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce_DataModel.GenericRepository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        TEntity GetByID(object id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
        void Update(TEntity entityToUpdate);
        void Delete(object id);
        void DeleteRange(IEnumerable<TEntity> entity);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
    }
}
