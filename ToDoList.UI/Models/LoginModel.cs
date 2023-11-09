using System.ComponentModel.DataAnnotations;

namespace ToDoList.UI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Input Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
