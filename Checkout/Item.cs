namespace Application;
public class Item
{
    public Item(string sku, int price, SpecialPrice? specialPrice = null)
    {
        SKU = sku;
        Price = price;
        SpecialPrice = specialPrice ?? null!;
    }

    public string SKU { get; }
    public int Price { get; }
    public SpecialPrice SpecialPrice { get; }
}