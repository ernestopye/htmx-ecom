namespace Ecommerce;

public class CartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}