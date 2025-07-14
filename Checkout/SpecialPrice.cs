namespace Application
{
    public class SpecialPrice
    {
        public SpecialPrice(int quantity, Money price)
        {
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; }
        public Money Price { get; }

    }
}