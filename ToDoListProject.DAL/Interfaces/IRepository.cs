using System.Linq.Expressions;

namespace ToDoList.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        public Task<TEntity> GetById(int id);

        public Task<TEntity> Add(TEntity obj);

        public Task<TEntity> Delete(int id);

        public Task<TEntity> Delete(TEntity obj);

        public Task<TEntity> Update(TEntity obj);
    }
}
