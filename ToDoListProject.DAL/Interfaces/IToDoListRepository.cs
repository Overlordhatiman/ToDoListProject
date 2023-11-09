using System.Linq.Expressions;
using ToDoList.DAL.Models;

public interface IToDoListRepository
{
    public Task<IEnumerable<ToDoList.DAL.Models.ToDoList>> GetAll();

    Task<IQueryable<ToDoList.DAL.Models.ToDoList>> Get(
        Expression<Func<ToDoList.DAL.Models.ToDoList, bool>> filter = null,
        Func<IQueryable<ToDoList.DAL.Models.ToDoList>, IOrderedQueryable<ToDoList.DAL.Models.ToDoList>> orderBy = null,
        string includeProperties = "");

    public Task<ToDoList.DAL.Models.ToDoList> GetById(int id);

    public Task<ToDoList.DAL.Models.ToDoList> Add(ToDoList.DAL.Models.ToDoList obj);

    public Task<ToDoList.DAL.Models.ToDoList> Delete(int id);

    public Task<ToDoList.DAL.Models.ToDoList> Delete(ToDoList.DAL.Models.ToDoList obj);

    public Task<ToDoList.DAL.Models.ToDoList> Update(ToDoList.DAL.Models.ToDoList obj);

    public Task<ToDoList.DAL.Models.ToDoList> UpdateData(ToDoList.DAL.Models.ToDoList obj);
}