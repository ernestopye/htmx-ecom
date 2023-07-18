using Ecommerce;

namespace HtmxEcomSample.Models;

public class UserSummaryViewModel {
    public bool IsHtmxRequest { get; set; }
    public int? TotalItemsInCart { get; set; } = null;
}

public class UserCartViewModel {
    public bool IsHtmxRequest { get; set; } = false;
    public IEnumerable<CartItem>? CartItems { get; set; }
}

public class UserRegisterViewModel {
    public bool IsHtmxRequest { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}