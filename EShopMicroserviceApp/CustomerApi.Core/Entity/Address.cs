using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Core.Entity;

public class Address
{
    public int Id { get; set; }
    [Required,Column(TypeName = "varchar(max)")]
    public string Street1 { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string? Street2 { get; set; }
    [Required,Column(TypeName = "varchar(21)")]
    public string City { get; set; }
    [Required,MaxLength(20)]
    public int ZipCode { get; set; }
    [Required,MaxLength(20)]
    public string State { get; set; }
    [Required,MaxLength(30)]
    public string Country { get; set; }
    public List<CustomerAddress> CustomerAddressesList { get; set; }
}