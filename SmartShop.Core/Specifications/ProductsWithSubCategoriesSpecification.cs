using SmartShop.Core.Specifications;

namespace SmartShop.Core;

public class ProductsWithSubCategoriesSpecification : BaseSpecification<Product>
{
    //need to rename this to ProductsWithTypesAndBrandsSpecification
    public ProductsWithSubCategoriesSpecification(ProductSpecParams productParams)
     : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
    {
        AddInclude(x => x.SubCategory);
        AddOrderBy(x => x.Name);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public ProductsWithSubCategoriesSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.SubCategory);
    }
}
