using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Request;

public class PaymentTypeRequestModel
{
    public string Name { get; set; }

    public List<PaymentMethod> PaymentMethods { get; set; }
}