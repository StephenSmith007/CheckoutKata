using System.Diagnostics;

namespace Application;

public class Checkout : ICheckout
{
    Dictionary<Item, int> _scannedItems = new Dictionary<Item, int>();

    private readonly IRepository _repository;

    public Checkout(IRepository repository)
    {
        _repository = repository;
    }

    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var item in _scannedItems)
        {
            int bundles = item.Key.SpecialPrice != null ? item.Value / item.Key.SpecialPrice.Quantity : 0;
            int remainder = item.Value - (bundles * (item.Key.SpecialPrice?.Quantity ?? 0));

            totalPrice += item.Key.SpecialPrice?.Price * bundles ?? 0;
            totalPrice += item.Key.Price * remainder;
        }

        return totalPrice;
    }

    public void Scan(string item)
    {
        var itemObj = _repository.GetItem(item);

        if (_scannedItems.ContainsKey(itemObj))
        {
            _scannedItems[itemObj]++;
        }
        else
        {
            _scannedItems.Add(itemObj, 1);
        }
    }
}
