using System.Linq.Expressions;
using LinqKit;

namespace PersonalBlog.Repositorys;

public interface IRepository<T> where T : class
{
    public Task<T> Add(T entity);
    public Task<T> Update(T entity);
    public Task<List<T>> All();
    public Task<T?> Get(int id);
    public Task<List<T>> Where(Expression<Func<T, bool>> predicate);
}