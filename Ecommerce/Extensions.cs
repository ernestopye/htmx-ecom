using System.Globalization;

public static class EcommerceExtensions {
    public static string ToCurrency(this decimal value) {
        return value.ToString("C", new CultureInfo("en-US"));
    }
}