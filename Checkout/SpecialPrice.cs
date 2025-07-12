namespace Application
{
    public class SpecialPrice
    {
        public SpecialPrice(int quantity, int price)
        {
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; }
        public int Price { get; }

    }
}