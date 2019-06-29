using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Entities;
using ToDoList.Facade.Contracts;
using ToDoList.Facade.Dto.User;

namespace ToDoList.Facade.Services
{
    public class LoginApp : ILoginApp
    {

        private readonly IUserService userService;

        public LoginApp(IUserService _userService)
        {
            userService = _userService;
        }

        public bool Register(RegisterDto registerDto, out int userId)
        {
            var newUser = new User
            {
                Name = registerDto.Name,
                UserName = registerDto.UserName,
                Password = registerDto.Password,
            };

            var register =  userService.Insert(newUser);
            userId = newUser.Id;

            return register;
        }

        public bool UserExists(string userName)
        {
            return userService.Exist(userName);
        }

        public bool ValidLogin(string userName, string password, out int userId)
        {
            return userService.ValidLogin(userName, password, out userId);
        }

    }
}
