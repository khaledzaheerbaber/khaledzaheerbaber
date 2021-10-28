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
    public class DepartementService : IDepartementService
    {
        private IUnitOfWork _unitOfWork;

        public DepartementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Department> GetAll()
        {
            var departments = new List<Department>();
            departments.Add(new Department { Id = Guid.NewGuid(), DepartmentName = "HR" });
            departments.Add(new Department { Id = Guid.NewGuid(), DepartmentName = "Accounts" });
            return departments.ToList();
        }
    }
}