namespace CustomerApi.Core.Entity;

public class CustomerAddress
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public bool IsDefaultAddress { get; set; } = false;
    public Customer Customer { get; set; }
    public Address Address { get; set; }
    
}