namespace Application;
public class Item
{
    public Item(string sku, Money price, SpecialPrice? specialPrice = null)
    {
        SKU = sku;
        Price = price;
        SpecialPrice = specialPrice ?? null!;
    }

    public string SKU { get; }
    public Money Price { get; }
    public SpecialPrice SpecialPrice { get; }
}