namespace ProductApi.Core.Entity;

public class VariationValue
{
    public int Id { get; set; }
    public int VariationId { get; set; }
    public int Value { get; set; }
    public CategoryVariation CategoryVariation { get; set; }
    public List<ProductVariationValue> ProductVariationValues { get; set; }
    
}