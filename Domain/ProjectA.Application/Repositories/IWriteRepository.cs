namespace ProjectA.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T item);
        Task<bool> AddAsync(List<T> items);
        bool Remove(T item);
        bool Remove(string id);
        bool RemoveAll(List<T> items);
        bool Update(T item);
        bool UpdateAll(List<T> items);
    }
}
