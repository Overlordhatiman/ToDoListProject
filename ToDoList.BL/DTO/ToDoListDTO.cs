namespace ToDoList.BL.DTO
{
    public class ToDoListDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public bool IsFinished { get; set; }

        public UserDTO? User { get; set; }
    }
}
