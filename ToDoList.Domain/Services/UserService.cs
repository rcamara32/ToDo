using System.Linq;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public bool Exist(string userName)
        {
            var exist = userRepository.GetAllItems()
                .Any(x => x.UserName == userName);

            return exist;
        }

        public bool Insert(User newUser)
        {
            var register = false;

            var exist = Exist(newUser.UserName);

            if (!exist)
            {               
                register = userRepository.Insert(newUser);
            }

            return register;
        }

        public bool ValidLogin(string userName, string password, out int userId)
        {
            var valid = false;
            var user = userRepository.GetAllItems()
                .FirstOrDefault(x => x.UserName == userName && x.Password == password);
            
            if (user != null)
            {
                valid = true;    
                userId = user.Id;
            }
            else
            {
                userId = 0;
            }

            return valid;
        }
    }

}
