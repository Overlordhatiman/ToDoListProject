using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.DAL.Interfaces;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IQueryable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query);
        }
        return query;
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> Delete(int id)
    {
        TEntity entityToDelete = await _dbSet.FindAsync(id);

        var result =  await Delete(entityToDelete);
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<TEntity> Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        var obj = _dbSet.Remove(entityToDelete);
        await _context.SaveChangesAsync();

        return obj.Entity;
    }

    public async Task<TEntity> Update(TEntity entityToUpdate)
    {
        _dbSet.Update(entityToUpdate);
        await _context.SaveChangesAsync();

        return entityToUpdate;
    }
}