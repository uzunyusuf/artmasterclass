﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace MKT.Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {

        private readonly TransactionOptions _transactionOtions = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.Snapshot
        };


        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                foreach (var property in includeProperties)
                {
                    set = set.Include(property);
                    set.Load();
                }
                return set.SingleOrDefault(filter);
            }
        }

        public TEntity GetWithLoad(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                set.Load();
                return set.SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                set.Load();
                foreach (var property in includeProperties)
                {
                    set = set.Include(property);
                }
                set.Load();
                return filter == null
                    ? set.ToList()
                    : set.Where(filter).ToList();
            }

        }

        public List<TEntity> GetListWithDetails(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                if (include != null)
                {
                    set = include(set);
                }

                return filter == null
                    ? set.ToList()
                    : set.Where(filter).ToList();
            }

        }

        public List<TEntity> GetListWithLoad(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> set = context.Set<TEntity>();
                set.Load();
                return filter == null ? set.ToList() : set.Where(filter).ToList();
            }
        }

        public virtual void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, _transactionOtions))
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    scope.Complete();
                }
                
            }
        }

        public void AddMultiple(IEnumerable<TEntity> Entities)
        {
            using (var context = new TContext())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, _transactionOtions))
                {
                    foreach (var entity in Entities)
                    {
                        var addedEntity = context.Entry(entity);
                        addedEntity.State = EntityState.Added;
                    }
                    context.SaveChanges();
                    scope.Complete();
                }
            }
                
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, _transactionOtions))
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, _transactionOtions))
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public DbContext GetContext()
        {
            return new TContext();
        }
    }
}