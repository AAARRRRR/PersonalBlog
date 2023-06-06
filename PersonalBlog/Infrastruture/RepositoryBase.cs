using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Infrastruture;

public abstract class RepositoryBase<T, TDbContext> : IRepository<T>
    where T: class
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    protected RepositoryBase(TDbContext dbContext) 
    {
        _dbContext = dbContext;
    }
    
    //增
    public Task<T> Add(T entity)
    {
        var createdEntity = _dbContext.Add(entity).Entity;
        _dbContext.SaveChanges();
        return Task.FromResult(createdEntity);
    }
    
    //删
    public void Remove(T entity)
    {
        var deletedEntity = _dbContext.Remove(entity).Entity;
        _dbContext.SaveChanges();
    }
    
    //改
    public Task<T> Update(T entity)
    {
        var updatedEntity = _dbContext.Update(entity).Entity;
        _dbContext.SaveChanges();
        return Task.FromResult(updatedEntity);
    }

    //查
    public Task<T?> Get(int id)
    {
        return Task.FromResult(_dbContext.Find<T>(id));
    }
    
    public Task<List<T>> All()
    {
        return Task.FromResult(_dbContext.Set<T>().AsNoTracking().ToList());
    }

    public Task<List<T>> Where(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate).ToListAsync();
    }
}