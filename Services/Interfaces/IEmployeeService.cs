using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(Guid Id);
        void Update(Employee employee);
        void Add(Employee employee);
        void Delete(Guid Id);
    }
}
