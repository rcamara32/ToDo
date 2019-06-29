using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Services;

namespace ToDoList.Domain.Test.TodoTest
{
    /// <summary>
    /// Summary description for Todo
    /// </summary>
    [TestClass]
    public class TodoTest
    {

        Mock<ITodoRepository> mockTodoRepository = new Mock<ITodoRepository>();

        Todo newTodo = new Todo
        {
            Id = 5,
            Description = "New Task",
            Done = false,
            ModificationDate = DateTime.Now,
            UserId = 4
        };
               

        public TodoTest()
        {
            var listTodo = new List<Todo>();

            var todo1 = new Todo
            {
                Id = 1,
                Description = "Make Resume",
                ModificationDate = DateTime.Now,
                Done = false,
                UserId = 1
            };
            listTodo.Add(todo1);

            listTodo.Add(new Todo
            {
                Id = 2,
                Description = "Send Resume to Deloitte",
                ModificationDate = DateTime.Now,
                Done = true,
                UserId = 1
            });
            listTodo.Add(new Todo
            {
                Id = 3,
                Description = "Make Interview with David Lyons",
                ModificationDate = DateTime.Now,
                Done = true,
                UserId = 2
            });            

            mockTodoRepository.Setup(x => x.GetByUser(2)).Returns(listTodo.Where(x=> x.UserId == 2).AsQueryable());
            mockTodoRepository.Setup(x => x.GetById(1)).Returns(todo1);
            mockTodoRepository.Setup(x => x.Update(todo1)).Returns(true);           
            mockTodoRepository.Setup(x => x.Insert(newTodo)).Returns(true);
            mockTodoRepository.Setup(x => x.Delete(todo1)).Returns(true);
        }

        [TestMethod]
        public void Return_Qtde_Items_By_User()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.GetByUser(2);
            Assert.IsNotNull(retorno);
            Assert.AreEqual(1, retorno.Count());
        }

        [TestMethod]
        public void Return_Existing_Todo_By_Id()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.GetById(1);
            Assert.IsNotNull(retorno);
        }       


        [TestMethod]
        public void Edit_Existing_Todo()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.Edit(1, "bla bla bla");
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Add_New_Todo()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.Add(newTodo);
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Mark_As_Done()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.Done(1, true);
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Delete_Todo_Id1()
        {
            var teste = new TodoService(mockTodoRepository.Object);
            var retorno = teste.Delete(1);
            Assert.IsTrue(retorno);
        }


    }
}
