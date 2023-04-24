namespace PersonalBlog.Repositorys;

public interface IRepository<T> where T : class
{
    public T Add(T entity);
    public T Update(T entity);
    public List<T> All();
    public T? Get(int id);

}