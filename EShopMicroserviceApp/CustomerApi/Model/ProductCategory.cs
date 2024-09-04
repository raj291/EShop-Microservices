namespace CustomerApi.Model;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParentCategoryId { get; set; }
}