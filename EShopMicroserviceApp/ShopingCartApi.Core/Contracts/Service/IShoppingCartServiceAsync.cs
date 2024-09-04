using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShopingCartApi.Core.Contracts.Service;

public interface IShoppingCartServiceAsync
{
    Task<int> InsertShoppingCartAsync(ShoppingCartRequestModel model);
    Task<int> DeleteShoppingCartAsync(int id);
    Task<int> UpdateShoppingCartAsync(ShoppingCartRequestModel model, int id);
    Task<ShoppingCartResponseModel> GetShoppingCartByIdAsync(int id);
    Task<IEnumerable<ShoppingCartResponseModel>> GetAllShoppingCartAsync();
}