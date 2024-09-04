using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Response;

public class PaymentMethodResponseModel
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public string AccountNumber { get; set; }
    public DateOnly Expiry { get; set; }
    public bool IsDefault { get; set; }
    public PaymentType PaymentType { get; set; }
}