using Application;

namespace CheckoutTests;

public class Tests
{
    Checkout _checkout;

    [SetUp]
    public void Setup()
    {
        _checkout = new Checkout();
    }
}