using Application;

namespace CheckoutTests;

public class Tests
{
    Checkout _checkout;

    [SetUp]
    public void Setup()
    {
        _checkout = new Checkout(new TestRepository());
    }

    [Test]
    public void Checkout_Starts_With_Price_Of_Zero()
    {
        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(0));
    }

    [TestCase("A", 50)]
    [TestCase("B", 30)]
    [TestCase("C", 20)]
    [TestCase("D", 15)]
    public void Scanning_One_Item_Returns_Price_Of_Single_Item(string item, int expectedPrice)
    {
        _checkout.Scan(item);

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase(new string[] { "A", "A" }, 100)]
    [TestCase(new string[] { "B", "B" }, 60)]
    [TestCase(new string[] { "A", "B" }, 80)]
    public void Scanning_Combination_Of_Two_Items_Returns_Combined_Price(string[] items, int expectedPrice)
    {
        foreach (var item in items)
            _checkout.Scan(item);

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [Test]
    public void Scanning_Unknown_Item_Throws_Error_But_Does_Not_Crash_Checkout()
    {
        Assert.Throws<ArgumentException>(() => _checkout.Scan(Guid.NewGuid().ToString()));

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(0));
    }
}