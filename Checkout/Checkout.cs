namespace Application;

public class Checkout : ICheckout
{
    public int GetTotalPrice()
    {
        var totalPrice = 0;

        return totalPrice;
    }

    public void Scan(string item)
    {
        throw new NotImplementedException();
    }
}
