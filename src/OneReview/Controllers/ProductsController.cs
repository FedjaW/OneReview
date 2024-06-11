using Microsoft.AspNetCore.Mvc;

namespace OneReview.Controllers;

[Route("[controller]")] // = [Route("products")] => /products
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        // create the product

        // return 201 created response
        return CreatedAtAction(
            // method
            actionName: nameof(Get),
            // parameters needed for this request
            routeValues: new { ProductId = Guid.NewGuid() },
            // resource
            value: request
        );
    }

    [HttpGet("{productId:guid}")]
    public IActionResult Get(Guid productId)
    {
        // get the product

        // return 200 ok response
        return Ok(
        // resoruce
        );
    }

    public record CreateProductRequest(string Name, string Category, string SubCategory);
}
