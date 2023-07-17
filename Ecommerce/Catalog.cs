namespace Ecommerce;

public static class Catalog {
    public static IEnumerable<Product> Products() {
        for (var i = 1; i <= 12; i++) {
            yield return new Product {
                Id = i,
                Name = $"Product {i}",
                Price = 19.99m
            };
        }
    }
}
