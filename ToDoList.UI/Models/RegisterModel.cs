using System.ComponentModel.DataAnnotations;

namespace ToDoList.UI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Input Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Input password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Uncorrect password")]
        public string? ConfirmPassword { get; set; }
    }
}
