using Microsoft.AspNetCore.Mvc;
using OneReview.Domain;
using OneReview.Services;

namespace OneReview.Controllers;

[ApiController]
[Route("[controller]")] // = [Route("products")] => /products
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        // mapping to internal representation
        var product = request.ToDomain();

        // invoking the usecase
        _productsService.Create(product);

        // mapping to external representation
        return CreatedAtAction(
            // method
            actionName: nameof(Get),
            // parameters needed for this request
            routeValues: new { ProductId = product.Id },
            // resource
            value: ProductResponse.FromDomain(product)
        );
    }

    [HttpGet("{productId:guid}")]
    public IActionResult Get(Guid productId)
    {
        // invoking the usecase
        var product = _productsService.Get(productId);

        // return 200 ok response
        return product is null
            ? Problem(
                statusCode: StatusCodes.Status404NotFound,
                detail: $"Product not found (productId: {productId})"
            )
            : Ok(ProductResponse.FromDomain(product));
    }

    public record CreateProductRequest(string Name, string Category, string SubCategory)
    {
        public Product ToDomain()
        {
            return new Product
            {
                Name = Name,
                Category = Category,
                SubCategory = SubCategory
            };
        }
    }

    public record ProductResponse(Guid Id, string Name, string Category, string SubCategory)
    {
        public static ProductResponse FromDomain(Product product)
        {
            return new ProductResponse(
                product.Id,
                product.Name,
                product.Category,
                product.SubCategory
            );
        }
    }
}
