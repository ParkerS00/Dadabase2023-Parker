namespace Dadabase.Services;

public interface IJokeService<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<T> Add(T obj);
    Task<T> Update(T obj);
    Task<T> Delete(int id);
}