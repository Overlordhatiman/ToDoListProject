namespace ToDoList.BL.DTO
{
    public class UserDTO
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<ToDoListDTO>? ToDoLists { get; set; } = new List<ToDoListDTO>();
    }
}
