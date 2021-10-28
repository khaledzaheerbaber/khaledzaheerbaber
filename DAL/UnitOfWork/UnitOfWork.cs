using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public partial class UnitOfWork : IDisposable, IUnitOfWork
    {

        private IBaseRepository<User> _userRepository;
        private IBaseRepository<Department> _departmentRepository;
        private IBaseRepository<Employee> _employeeRepository;


        private MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }


        public IBaseRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new BaseRepository<User>(_context);
                return _userRepository;
            }
        }

        public IBaseRepository<Department> DepartmentRepository
        {
            get
            {

                if (_departmentRepository == null)
                    _departmentRepository = new BaseRepository<Department>(_context);
                return _departmentRepository;
            }
        }

        public IBaseRepository<Employee> EmployeeRepository
        {
            get
            {

                if (_employeeRepository == null)
                    _employeeRepository = new BaseRepository<Employee>(_context);
                return _employeeRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
