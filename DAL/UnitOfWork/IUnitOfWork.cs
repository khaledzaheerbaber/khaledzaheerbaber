using DAL.Repositories.Interfaces;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<Employee> EmployeeRepository { get; }
        void Save();
    }
}
