using System.Linq;
using System.Web.Mvc;
using ToDoList.Facade.Contracts;
using ToDoList.Facade.Dto.Todo;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {

        private readonly ITodoApp todoApp;

        public TodoController(ITodoApp _todoApp)
        {
            todoApp = _todoApp;
        }

        // GET: Todo
        public ActionResult Index()
        {
            return View();
        }

        // GET: ToDo/GetAllTodoListByUser
        [HttpGet]
        public JsonResult GetAllTodoListByUser()
        {
            var sessionUserId = (int)Session["userId"];
            var todoListViewModel = todoApp.GetAllTodoListByUser(sessionUserId)
                .Select(x => new TodoListViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ModificationDate = x.ModificationDate.ToString("U"),
                    Done = x.Done
                }).ToList();

            return Json(todoListViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: ToDo/GetById?id=5
        [HttpGet]
        public JsonResult GetById(int id)
        {

            var todoDto = todoApp.GetById(id);

            if (todoDto != null)
            {
                var editTodo = new TodoListViewModel
                {
                    Id = todoDto.Id,
                    Description = todoDto.Description,
                    ModificationDate = todoDto.ModificationDate.ToString("U"),
                    Done = todoDto.Done
                };

                return Json(editTodo, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        // POST: Todo/Done
        [HttpPost]
        public JsonResult Done(DoneTodoDto doneTodoDto)
        {
            var done = todoApp.Done(doneTodoDto);
            return Json(done, JsonRequestBehavior.AllowGet);
        }

        // POST: Todo/Edit
        [HttpPost]
        public JsonResult Edit(NewTodoDto newTodoDto)
        {
            var edit = todoApp.Edit(newTodoDto);
            return Json(edit, JsonRequestBehavior.AllowGet);
        }

        // POST: Todo/Delete?id=5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var edit = todoApp.Delete(id);
            return Json(edit, JsonRequestBehavior.AllowGet);
        }

        // POST: Todo/Add
        [HttpPost]
        public JsonResult Add(AddTodoDto addTodoDto)
        {
            var sessionUserId = (int)Session["userId"];

            var added = todoApp.Add(addTodoDto, sessionUserId);
            return Json(added, JsonRequestBehavior.AllowGet);
        }

    }
}