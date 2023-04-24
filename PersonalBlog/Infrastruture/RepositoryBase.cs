using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Repositorys;

public abstract class RepositoryBase<T, TDbContext> : IRepository<T>
    where T: class
    where TDbContext : DbContext
{
    protected TDbContext _DbContext;


    public RepositoryBase(TDbContext dbContext) 
    {
        _DbContext = dbContext;
    }
    
    public T Add(T entity)
    {
        var createdEntity = _DbContext.Add(entity).Entity;
        _DbContext.SaveChanges();
        return createdEntity;
    }

    public T? Get(int id)
    {
        return _DbContext.Find<T>(id);
    }

    public List<T> All()
    {
        return _DbContext.Set<T>().AsNoTracking().ToList();
    }

    public T Update(T entity)
    {
        var updatedEntity = _DbContext.Update(entity).Entity;
        _DbContext.SaveChanges();
        return updatedEntity;
    }
}