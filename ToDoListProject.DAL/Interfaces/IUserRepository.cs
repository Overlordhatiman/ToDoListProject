using System.Linq.Expressions;
using ToDoList.DAL.Models;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);

    public Task<IEnumerable<User>> GetAll();

    Task<IQueryable<User>> Get(
        Expression<Func<User, bool>> filter = null,
        Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
        string includeProperties = "");

    public Task<User> GetById(int id);

    public Task<User> Add(User obj);

    public Task<User> Delete(int id);

    public Task<User> Delete(User obj);

    public Task<User> Update(User obj);
}