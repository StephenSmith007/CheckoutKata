namespace Application;
public class Item
{
    public Item(string sku, int price)
    {
        SKU = sku;
        Price = price;
    }

    public string SKU { get; }
    public int Price { get; }
}