namespace Base.API.Repository
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid? uid);
        Task Add(T entity);
        Task Delete(Guid uid);
        Task Update(T entity);
    }
}