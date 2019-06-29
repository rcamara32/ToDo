using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Services;

namespace ToDoList.Domain.Test.User
{
    /// <summary>
    /// Summary description for UserTest
    /// </summary>
    [TestClass]
    public class UserTest
    {

        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

        public UserTest()
        {
            var listUser = new List<Entities.User>();

            listUser.Add(new Entities.User {
                Id = 1,
                Name = "Renan Camara",
                UserName = "rcamara32",
                Password = "123@456"
            });

            listUser.Add(new Entities.User
            {
                Id = 2,
                Name = "Deloitte",
                UserName = "deloitte",
                Password = "456@789"
            });

            listUser.Add(new Entities.User
            {
                Id = 3,
                Name = "Administrator",
                UserName = "admin",
                Password = "xpto@123"
            });

            var newUser = new ToDoList.Domain.Entities.User()
            {
                Name = "Renan Camara",
                UserName = "rcamara32",
                Password = "123@456"
            };

            mockUserRepository.Setup(x => x.Insert(newUser)).Returns(true);           

        }


        [TestMethod]
        public void Insert_New_User()
        {
            //arrange  
            var newUser = new Entities.User()
            {                
                Name = "Renan Camara",
                UserName = "rcamara32",
                Password = "123@456"
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.Insert(newUser)).Returns(true);

            var userService = new UserService(mockRepo.Object);
            var returnInsert  = userService.Insert(newUser);

            Assert.IsTrue(returnInsert);
        }

    }
}
