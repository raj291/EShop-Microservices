namespace ShopingCartApi.Core.Contracts.Repository;

public interface IRepositoryAsync<T> where T : class
{
    Task<int> InsertAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<int> UpdateAsync(T entity);
    Task<T> GetbyIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}