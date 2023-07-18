using Ecommerce;

namespace HtmxEcomSample.Models;

public class ProductDetailsViewModel{
    public Product Product {get; set;} = null!;
    public int? VariantId {get; set;}
}

public class ProductSearchViewModel {
    public List<Product> SearchResults = new();
}