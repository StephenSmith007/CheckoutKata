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

    [Test]
    public void Checkout_Starts_With_Price_Of_Zero()
    {
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(0));
    }
}