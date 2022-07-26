namespace ASPNETPaginationSortingHW.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Edit(T entity);
        Task<T> Get(int id);
        Task<int> Count();
        Task<IEnumerable<T>> Get(int page = 1, int count = 12, int orderBy = 0);
    }
}
