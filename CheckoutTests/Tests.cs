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

    [TestCase("A", 3, 130)]
    [TestCase("B", 2, 45)]
    public void Scanning_Multiple_Items_Returns_Special_Prices(string item, int quantity, int expectedPrice)
    {
        for (int i = 0; i < quantity; i++)
            _checkout.Scan(item);

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }

    [TestCase(new string[] { "A", "A" }, 100)]
    [TestCase(new string[] { "A", "B" }, 80)]
    [TestCase(new string[] { "A", "C" }, 70)]
    [TestCase(new string[] { "A", "D" }, 65)]
    [TestCase(new string[] { "B", "C" }, 50)]
    [TestCase(new string[] { "B", "D" }, 45)]
    [TestCase(new string[] { "C", "C" }, 40)]
    [TestCase(new string[] { "C", "D" }, 35)]
    [TestCase(new string[] { "D", "D" }, 30)]
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

    [Test]
    public void Scanning_Null_Item_Throws_Error_But_Does_Not_Crash_Checkout()
    {
        Assert.Throws<ArgumentNullException>(() => _checkout.Scan(null));

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(0));
    }

    [TestCase(new string[] { "A", "A", null, "A", "D" }, 145)]
    [TestCase(new string[] { "A", "A", "Unknown", "A", "D" }, 145)]
    [TestCase(new string[] { "A", "A", "B", "B", "C", "D", "A", "B", "C", "B", "A" }, 325)]
    public void Scanning_Multiple_Combinations_Items_Returns_Correct_Price(string[] items, int expectedPrice)
    {
        foreach (var item in items)
        {
            try
            {
                _checkout.Scan(item);
            }
            catch (Exception ex)
            {
                Assert.That(ex, Is.TypeOf<ArgumentException>().Or.TypeOf<ArgumentNullException>());
            }
                    
        }

        Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expectedPrice));
    }
}