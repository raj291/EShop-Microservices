namespace CustomerApi.Core.Contracts.Repository;

public interface IRepositoryAsync<T> where T : class
{
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAysnc(int id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}