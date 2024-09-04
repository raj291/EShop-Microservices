using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Core.Entity;

public class Customer
{
    public int Id { get; set; }
    [Required, Column(TypeName = "varchar(20)")]
    public string FirstName { get; set; }
    [Required,Column(TypeName = "varchar(20)")]
    public string LastName { get; set; }
    [Required,Column(TypeName = "varchar(10)")]
    public string Gender { get; set; }
    [Required,Column(TypeName = "varchar(11)")]
    public string Phone { get; set; }
    public List<CustomerAddress> CustomerAddressesList { get; set; }
}