using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Competition.App.Domain.Repository
{
    public class Repository : IDisposable, IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves the changes
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Executes query 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        /// <summary>
        /// Gets single value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T SingleOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Inserts new row into the table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Insert<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates the table
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="entity">entity type</param>
        public void Update<T>(T entity) where T : class
        {
            DbEntityEntry entityEntry = _dbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
                entityEntry.State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Deletes row from the table
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="entity">entity</param>
        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Deletes row by id
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="id">Id</param>
        public void Delete<T>(int id) where T : class
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Gets row by id
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="intId">int id</param>
        /// <returns>Entity row from type T</returns>
        public T GetById<T>(int intId) where T : class
        {
            return _dbContext.Set<T>().Find(intId);
        }

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="originalModelId">Model id</param>
        /// <param name="newEntity">New values</param>
        public void UpdateEntity<T>(int originalModelId, T newEntity) where T : class
        {
            var originalEntityModel = _dbContext.Set<T>().Find(originalModelId);

            _dbContext.Entry(originalEntityModel).CurrentValues.SetValues(newEntity);
        }


        /// <summary>
        /// Gets all rows
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <returns>List of items</returns>
        public List<T> GetAll<T>(string tabelsToInclude) where T : class
        {
            if (string.IsNullOrEmpty(tabelsToInclude))
            {
                return _dbContext.Set<T>().ToList();
            }
            else
            {
                return _dbContext.Set<T>().Include(tabelsToInclude).ToList();
            }
        }


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }


        public void ExecuteCommand(string query)
        {
            _dbContext.Database.ExecuteSqlCommand(query);
        }
    }
}
