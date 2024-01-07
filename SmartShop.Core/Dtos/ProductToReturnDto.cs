namespace SmartShop.Core;

public record class ProductToReturnDto
{
    public required string Name { get; set; }
    public float Rate { get; set; }
    public bool InStock { get; set; }
    public int Quantity { get; set; }
    public int SubCategoryId { get; set; }
    public required string SubCategory { get; set; }
    public required string Brand { get; set; }
    public string Color { get; set; } = string.Empty;
    public required string PictureUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
