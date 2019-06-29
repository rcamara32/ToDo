using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "{0} is required")]        
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(20, ErrorMessage = "{0} must be 20 characters or less")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}