using ToDoList.DAL.Models;

namespace ToDoList.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return (User)(await Get(u => u.Email == username));
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return (User)(await Get(u => u.Email == username && u.Password == password));
        }
    }
}
