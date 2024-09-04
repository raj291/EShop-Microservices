using System.ComponentModel.DataAnnotations;
using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Response;

public class PaymentTypeResponseModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<PaymentMethod> PaymentMethods { get; set; }
}