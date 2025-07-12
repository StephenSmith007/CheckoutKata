using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTests;

public class TestRepository : IRepository
{
    private readonly Dictionary<string, Item> _items = new Dictionary<string, Item>
    {
        { "A", new Item(sku: "A", price: 50, specialPrice: new SpecialPrice(3,130)) },
        { "B", new Item(sku: "B", price: 30, specialPrice: new SpecialPrice(2,45)) },
        { "C", new Item(sku: "C", price: 20) },
        { "D", new Item(sku: "D", price: 15) }
    };

    public Item GetItem(string item)
    {
        if (_items.TryGetValue(item, out var foundItem))
            return foundItem;

        throw new ArgumentException($"Item '{item}' not found.");
    }
}
