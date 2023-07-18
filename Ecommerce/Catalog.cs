namespace Ecommerce;

public static class Catalog {
    public static IEnumerable<Product> Products() {
        for (var i = 1; i <= 12; i++) {
            yield return new Product {
                Id = i,
                Name = $"Product {i}",
                Price = (decimal)(GetPseudoDoubleWithinRange(1000, 5000) / 100)
            };
        }
    }

    public static VariantDetails? GetVariantName(int variantId) {
        switch (variantId) {
            case 1:
                return new VariantDetails(1, "Red", "f00");
            case 2:
                return new VariantDetails(2, "Green", "0a0");
            case 3:
                return new VariantDetails(3, "Blue", "00f");
            default:
                return null;
        }
    }

    public static double GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
    {
        var random = new Random();
        var rDouble = random.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return rRangeDouble;
    }
}

public record VariantDetails(int Id, string Name, string Color);
