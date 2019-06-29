namespace ToDoList.Web.Models
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ModificationDate { get; set; }
        public bool Done { get; set; }
    }
}