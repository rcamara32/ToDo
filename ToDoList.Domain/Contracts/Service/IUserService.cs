using System.Linq;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts.Service
{
    public interface IUserService
    {
        bool Exist(string userName);
        bool ValidLogin(string userName, string password, out int userId);
        bool Insert(User newUser);
    }
}
