namespace Application;

public interface ICheckout
{
    void Scan(string item);
    Money GetTotalPrice();
}