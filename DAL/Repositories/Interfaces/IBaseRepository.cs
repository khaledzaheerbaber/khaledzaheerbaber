using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(Guid id);

        IQueryable<T> GetAll();

        void Edit(T entity);

        void Insert(T entity);

        void Delete(T entity);

    }
}
