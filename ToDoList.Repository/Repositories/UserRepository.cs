using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Repository.Context;

namespace ToDoList.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(TodoContext todoContext)
            : base(todoContext)
        {
        }


    }
}
