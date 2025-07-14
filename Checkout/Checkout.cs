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

    public Money GetTotalPrice()
    {
        Money totalPrice = new Money(new decimal(0));

        foreach (var item in _scannedItems)
        {
            if (item.Key.SpecialPrice != null) // Ensure SpecialPrice is not null
            {
                int bundles = item.Value / item.Key.SpecialPrice.Quantity;
                int remainder = item.Value - (bundles * item.Key.SpecialPrice.Quantity);

                for (int i = 0; i < bundles; i++)
                    totalPrice += item.Key.SpecialPrice.Price;

                for (int j = 0; j < remainder; j++)
                    totalPrice += item.Key.Price;
            }
            else
            {
                for (int k = 0; k < item.Value; k++)
                    totalPrice += item.Key.Price;
            }
        }

        return totalPrice;
    }

    public void Scan(string item)
    {
        ArgumentNullException.ThrowIfNull(item);

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
