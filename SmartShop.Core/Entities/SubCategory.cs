namespace SmartShop;

public class SubCategory : BaseEntity
{
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public required Category Category { get; set; } 

}
