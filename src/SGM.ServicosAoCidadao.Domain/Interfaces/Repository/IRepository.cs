﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

    }
}
