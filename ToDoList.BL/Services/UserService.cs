using ToDoList.BL.DTO;
using ToDoList.BL.Interfaces;
using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Models;

namespace ToDoList.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserAsync(int userId)
        {
            return Mapper.MapUserToDTO(await _userRepository.GetById(userId));
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return Mapper.MapUsersToDTO(await _userRepository.GetAll());
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Mapper.MapUserToDTO(await _userRepository.Add(Mapper.MapDTOToUser(user)));
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Mapper.MapUserToDTO(await _userRepository.Update(Mapper.MapDTOToUser(user)));
        }

        public async Task<UserDTO> DeleteUserAsync(int userId)
        {
            var user = await GetUserAsync(userId);

            if (user == null)
            {
                return null;
            }

            return Mapper.MapUserToDTO(await _userRepository.Delete(userId));
        }

        public async Task<UserDTO> RegisterAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password are required.");
            }
            var existingUser = (await _userRepository.Get(x => x.Email == email)).FirstOrDefault();
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var user = new UserDTO
            {
                Email = email,
                Password = password
            };

            return Mapper.MapUserToDTO(await _userRepository.Add(Mapper.MapDTOToUser(user)));
        }

        public async Task<bool> IsValidUserAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password are required.");
            }
            var existingUser = await _userRepository.Get(x => x.Email == email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }
            else
                return true;
        }

        public async Task<UserDTO> GetUserAsync(string email, string password)
        {
            var user = (await _userRepository.Get(x => x.Email == email && x.Password == password)).FirstOrDefault();

            if (user != null)
            {
                return Mapper.MapUserToDTO(user);
            }

            return null;
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            var user = (await _userRepository.Get(x => x.Email == email)).FirstOrDefault();

            if (user != null)
            {
                return Mapper.MapUserToDTO(user);
            }

            return null;
        }

    }
}