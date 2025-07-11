namespace Application;

public class Checkout : ICheckout
{
    List<string> _scannedItems = new List<string>();
    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var item in _scannedItems)
        {
            switch (item)
            {
                case "A":
                    totalPrice += 50;
                    break;
                case "B":
                    totalPrice += 30;
                    break;
                default:
                    throw new ArgumentException($"Unknown item: {item}");
            }
        }

        return totalPrice;
    }

    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }
}
