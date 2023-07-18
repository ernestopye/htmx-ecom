namespace Ecommerce;

public static class CartRepository
{
    private static List<CartItem> _items = new();
    private static int fakeCounter = 0;

    public static void AddItem(Product product)
    {
        var existingItem = _items.FirstOrDefault(item => item.ProductId == product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity++;
            return;
        }

        _items.Add(new CartItem
        {
            Id = ++fakeCounter,
            ProductId = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = 1
        });
    }

    public static void RemoveItem(int cartItemId)
    {
        _items.RemoveAll(item => item.Id == cartItemId);
    }

    public static IEnumerable<CartItem> GetItems()
    {
        return _items;
    }

    public static void Clear()
    {
        _items.Clear();
    }

    public static decimal GetTotal()
    {
        return _items.Sum(item => item.Price * item.Quantity);
    }

    public static int GetTotalCount()
    {
        return _items.Sum(item => item.Quantity);
    }
}
