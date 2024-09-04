using Microsoft.EntityFrameworkCore;
using OrderApi.Core.Contracts.Repository;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T>  where T : class
{
    private readonly OrderDbContext _orderDbContext;

    public BaseRepositoryAsync(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await _orderDbContext.Set<T>().AddAsync(entity);
        return await _orderDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _orderDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _orderDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAysnc(int id)
    {
        var result = await GetByIdAsync(id);
        if (result != null)
        {
            _orderDbContext.Set<T>().Remove(result);
            return await _orderDbContext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _orderDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _orderDbContext.Set<T>().ToListAsync();
    }
} 