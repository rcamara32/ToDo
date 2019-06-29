using ToDoList.Facade.Dto.User;

namespace ToDoList.Facade.Contracts
{
    public interface ILoginApp
    {
        bool UserExists(string userName);
        bool ValidLogin(string userName, string password, out int userId);
        bool Register(RegisterDto registerDto, out int userId);
        
    }
}
