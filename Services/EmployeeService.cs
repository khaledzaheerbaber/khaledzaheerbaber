using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Entity.Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Employee employee)
        {
            //_unitOfWork.EmployeeRepository.Insert(employee);
            //_unitOfWork.Save();
        }

        public void Delete(Guid Id)
        {
            //var employee = _unitOfWork.EmployeeRepository.GetById(Id);
            //_unitOfWork.EmployeeRepository.Delete(employee);
            //_unitOfWork.Save();
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee { Id = Guid.NewGuid(), FirstName = "FirstName1" });
            employees.Add(new Employee { Id = Guid.NewGuid(), FirstName = "FirstName1" });
            return employees.ToList();
        }

        public Employee GetById(Guid Id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(Id);
            return employee;

        }

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Edit(employee);
            _unitOfWork.Save();
        }
    }
}