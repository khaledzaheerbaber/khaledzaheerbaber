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
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<User> GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            return users.ToList();
        }

        public User GetById(Guid id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            return user;
        }

        public User ValidateUser(string username, string password)
        {
            var user = new User();
            var userList = _unitOfWork.UserRepository.GetAll();
            user = userList.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
