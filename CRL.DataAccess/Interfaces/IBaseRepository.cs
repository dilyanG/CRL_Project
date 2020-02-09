using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        DataContext Context { get; set; }

        void Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
