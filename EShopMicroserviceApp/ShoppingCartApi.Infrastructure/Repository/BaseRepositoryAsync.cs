using Microsoft.EntityFrameworkCore;
using ShopingCartApi.Core.Contracts.Repository;
using ShoppingCartApi.Infrastructure.Data;

namespace ShoppingCartApi.Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly ShoppingCartDbContext _shoppingCartDbContext;

    public BaseRepositoryAsync(ShoppingCartDbContext shoppingCartDbContext)
    {
        _shoppingCartDbContext = shoppingCartDbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
       await  _shoppingCartDbContext.Set<T>().AddAsync(entity);
       return await _shoppingCartDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = await GetbyIdAsync(id);
        if (result != null)
        {
            _shoppingCartDbContext.Set<T>().Remove(result);
            return await _shoppingCartDbContext.SaveChangesAsync();
        }

        return 0;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _shoppingCartDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _shoppingCartDbContext.SaveChangesAsync();
    }

    public async Task<T> GetbyIdAsync(int id)
    {
        return await _shoppingCartDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _shoppingCartDbContext.Set<T>().ToListAsync();
    }
}