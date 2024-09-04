using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Request;

public class PaymentMethodRequestModel
{
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public string AccountNumber { get; set; }
    public DateOnly Expiry { get; set; }
    public bool IsDefault { get; set; }
    public PaymentType PaymentType { get; set; }
}