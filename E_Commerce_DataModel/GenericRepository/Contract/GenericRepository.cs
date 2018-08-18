using E_Commerce_DataModel.DataModel;
using E_Commerce_DataModel.GenericRepository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace E_Commerce_DataModel.GenericRepository.Contract
{
   public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region internal regions for DBCOntext
        internal E_CommerceDBContext Context;
        internal DbSet<TEntity> DbSet;
        #endregion

        #region public constructor...

        public GenericRepository(E_CommerceDBContext contextTars)
        {
            this.Context = contextTars;
            this.DbSet = Context.Set<TEntity>();
        }
        #endregion

        #region public Members

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.First<TEntity>(predicate);
        }


        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet;
            return query.Where(predicate).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void DeleteRange(IEnumerable<TEntity> entity)
        {
            DbSet.RemoveRange(entity);
        }

        #endregion

    }
}
