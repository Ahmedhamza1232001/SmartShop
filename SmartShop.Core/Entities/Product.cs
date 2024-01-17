using SmartShop.Core;
using SmartShop.Entities;
using SmartShop.Enums;

namespace SmartShop;

public abstract class Product : BaseEntity
{
    public required string Name { get; set; }
    public float Rate { get; set; }
    public bool InStock { get; set; } 
    public int Quantity { get; set; }
    public int SubCategoryId { get; set; }
    public required SubCategory SubCategory { get; set; }
    //need to make type act as subcategory but at the end of project
    public int ProductTypeId { get; set; } 
    public required ProductType ProductType { get; set; }  
    public int ProductBrandId { get; set; }
    public required ProductBrand ProductBrand { get; set; }
    public Color Color { get; set; }
    public required string PictureUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
