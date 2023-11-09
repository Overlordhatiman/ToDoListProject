using ToDoList.BL.DTO;

namespace ToDoList.BL.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserAsync(int userId);

        public Task<UserDTO> GetUserAsync(string email);

        public Task<UserDTO> GetUserAsync(string email, string password);

        public Task<List<UserDTO>> GetAllUsersAsync();

        public Task<UserDTO> CreateUserAsync(UserDTO user);

        public Task<UserDTO> UpdateUserAsync(UserDTO user);

        public Task<UserDTO> DeleteUserAsync(int id);

        public Task<UserDTO> RegisterAsync(string username, string password);

        public Task<bool> IsValidUserAsync(string email, string password);
    }
}
