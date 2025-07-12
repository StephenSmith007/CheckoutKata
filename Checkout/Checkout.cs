namespace Application;

public class Checkout : ICheckout
{
    List<Item> _scannedItems = new List<Item>();

    private readonly IRepository _repository;

    public Checkout(IRepository repository)
    {
        _repository = repository;
    }

    public int GetTotalPrice()
    {
        var totalPrice = 0;

        foreach (var item in _scannedItems)
            totalPrice += item.Price;

        return totalPrice;
    }

    public void Scan(string item)
    {
        _scannedItems.Add(_repository.GetItem(item));
    }
}
