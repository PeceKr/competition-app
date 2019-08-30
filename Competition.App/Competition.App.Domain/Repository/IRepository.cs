﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Competition.App.Domain.Repository
{
    public interface IRepository
    {
        void Save();
        IQueryable<T> Query<T>(Expression<Func<T, bool>> filter = null) where T : class;
        T SingleOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        T GetById<T>(int intId) where T : class;
        void UpdateEntity<T>(int originalModelId, T newEntity) where T : class;
        ICollection<T> GetAll<T>() where T : class;
    }
}
