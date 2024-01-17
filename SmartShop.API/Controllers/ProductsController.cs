using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartShop.Core;

namespace SmartShop.API;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> _productsRepo;
    private readonly IMapper _mapper;
    public ProductsController(IGenericRepository<Product> productsRepo, IMapper mapper)
    {
        _productsRepo = productsRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
        [FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductsWithSubCategoriesSpecification(productParams);
        var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

        var totalItems = await _productsRepo.CountAsync(countSpec);
        var products = await _productsRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

        return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
                productParams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithSubCategoriesSpecification(id);

        var product = await _productsRepo.GetEntityWithSpec(spec);

        return _mapper.Map<Product, ProductToReturnDto>(product);
    }
}
