using Application;

namespace CheckoutTests;

public class TestRepository : IRepository
{
    private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>
    {
        { "A", new Item(sku: "A", price: new Money(50), specialPrice: new SpecialPrice(3, new Money(130))) },
        { "B", new Item(sku: "B", price: new Money(30), specialPrice: new SpecialPrice(2, new Money(45))) },
        { "C", new Item(sku: "C", price: new Money(20)) },
        { "D", new Item(sku: "D", price: new Money(15)) }
    };

    public Item GetItem(string item)
    {
        if (_items.TryGetValue(item, out var foundItem))
            return foundItem;

        throw new ArgumentException($"Item '{item}' not found.");
    }
}
