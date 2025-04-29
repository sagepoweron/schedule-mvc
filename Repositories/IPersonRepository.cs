namespace schedule_mvc.Repositories
{
    public interface IPersonRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        bool Exists(Guid? id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T? GetById(Guid? id);
        Task<T?> GetByIdAsync(Guid? id);
        int GetTotal();
        IQueryable<T> QueryLikeName(string name);
        Task SaveAsync();
        void Update(T entity);
    }
}