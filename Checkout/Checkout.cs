namespace Application;

public class Checkout : ICheckout
{
    List<string> _scannedItems = new List<string>();

    Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        { "A", 50 },
        { "B", 30 },
        { "C", 20 },
        { "D", 15 }
    };

    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var item in _scannedItems)
        {
            if (!itemPrices.ContainsKey(item))
                throw new ArgumentException($"Unknown item: {item}");

            totalPrice += itemPrices[item];
        }

        return totalPrice;
    }

    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }
}
