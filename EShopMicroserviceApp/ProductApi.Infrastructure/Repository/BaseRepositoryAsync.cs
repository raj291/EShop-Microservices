using Microsoft.EntityFrameworkCore;
using ProductApi.Core.Contracts.Repository;
using ProductApi.Infrastructure.Data;

namespace ProductApi.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class 
{
    private readonly ProductDbcontext _productDbcontext;

    public BaseRepositoryAsync(ProductDbcontext productDbcontext)
    {
        _productDbcontext = productDbcontext;
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _productDbcontext.Set<T>().AddAsync(entity);
        return await _productDbcontext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _productDbcontext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _productDbcontext.SaveChangesAsync();
    }

    public async Task<int> DeleteAysnc(int id)
    {
        var result = await GetByIdAsync(id);
        if (result != null)
        {
            _productDbcontext.Set<T>().Remove(result);
            return await _productDbcontext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _productDbcontext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _productDbcontext.Set<T>().ToListAsync();
    }
}