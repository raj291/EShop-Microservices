using CustomerApi.Core.Contracts.Repository;
using CustomerApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly CustomerDbContext _customerDbContext;

    public BaseRepositoryAsync(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await _customerDbContext.Set<T>().AddAsync(entity);
        return await _customerDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _customerDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _customerDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAysnc(int id)
    {
        var result = await GetByIdAsync(id);
        if (result != null)
        {
            _customerDbContext.Set<T>().Remove(result);
            return await _customerDbContext.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _customerDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _customerDbContext.Set<T>().ToListAsync();
    }
}