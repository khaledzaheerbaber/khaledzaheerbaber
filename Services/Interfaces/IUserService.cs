using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User GetById(Guid id);
        User ValidateUser(string username, string password);
        List<User> GetAll();
    }
}
