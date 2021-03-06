﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Repositorys.Interface
{
  public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
         Task<List<T>> GetAllAsync();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
