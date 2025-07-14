using System.Diagnostics;

namespace Application;

public class Money
{
    public Money(decimal amount)
    {
        _amount = amount;
    }

    public Money()
    {
        _amount = 0m;
    }

    private decimal _amount;

    public decimal Amount { get { return Math.Round(_amount, 4); } }

    public static Money operator +(Money a, Money b)
    {
        return new Money(a.Amount + b.Amount);
    }

    public static Money operator -(Money a, Money b)
    {
        return new Money(a.Amount - b.Amount);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        // Compare the values of the Price objects
        Money otherPrice = (Money)obj;
        return Amount == otherPrice.Amount;
    }
}
