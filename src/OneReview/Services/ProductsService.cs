using OneReview.Domain;

namespace OneReview.Services;

public class ProductsService
{
    private static readonly List<Product> ProductsRepository = [];

    public void Create(Product product)
    {
        // store the product in the database
        ProductsRepository.Add(product);
    }

    public Product? Get(Guid productId)
    {
        return ProductsRepository.Find(x => x.Id == productId);
    }
}
