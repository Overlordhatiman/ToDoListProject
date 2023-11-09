using ToDoList.DAL.Models;

namespace ToDoList.DAL.Repositories
{
    public class ToDoListRepository : Repository<ToDoList.DAL.Models.ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ToDoListContext  context) : base(context)
        {
        }

        public async Task<ToDoList.DAL.Models.ToDoList> UpdateData(ToDoList.DAL.Models.ToDoList obj)
        {
            if(obj == null)
            {
                return null;
            }

            var todo = await GetById(obj.Id);
            todo.IsFinished = obj.IsFinished;
            todo.User = obj.User;
            todo.Description = obj.Description;
            todo.Title = obj.Title;

            return await Update(todo);
        }
    }
}
