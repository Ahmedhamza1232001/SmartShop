using SmartShop.Core.Specifications;

namespace SmartShop.Core;

public class ProductsWithSubCategoriesSpecification : BaseSpecification<Product>
{
    public ProductsWithSubCategoriesSpecification()
    {
        AddInclude(x => x.SubCategory);
    }

    public ProductsWithSubCategoriesSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.SubCategory);
    }
}
