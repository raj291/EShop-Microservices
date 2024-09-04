using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShopingCartApi.Core.Contracts.Service;

public interface IShoppingCartItemServiceAsync
{
    Task<int> InsertShoppingCartItemAsync(ShoppingCartItemRequestModel model);
    Task<int> DeleteShoppingCartItemAsync(int id);
    Task<int> UpdateShoppingCartItemAsync(ShoppingCartItemRequestModel model, int id);
    Task<ShoppingCartItemResponseModel> GetShoppingCartItemByIdAsync(int id);
    Task<IEnumerable<ShoppingCartItemResponseModel>> GetAllShoppingCartItemsAsync();
}