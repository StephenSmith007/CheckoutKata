namespace Application;

public class Checkout : ICheckout
{
    List<string> _scannedItems = new List<string>();
    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var item in _scannedItems)
        {
            if (item == "A")
            {
                totalPrice += 50;
            }
        }

        return totalPrice;
    }

    public void Scan(string item)
    {
        _scannedItems.Add(item);
    }
}
