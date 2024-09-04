using System.ComponentModel.DataAnnotations;

namespace ShopingCartApi.Core.Entity;

public class PaymentType
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<PaymentMethod> PaymentMethods { get; set; }
}