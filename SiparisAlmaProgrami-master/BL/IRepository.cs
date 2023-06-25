using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL
{
    interface IRepository<T> // <T> kullanarak interface i generic hale getirdik
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        int Add(T entity);
        T Find(int id);
        T Get(Expression<Func<T, bool>> expression);
        int Update(T entity);
        int Delete(T entity);
        int SaveChanges();
    }
}
