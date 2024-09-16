namespace Ticketautomat;

public class CreditCardPayment : IPayable
{
    public string Pay(double cash)
    {
        return $"Paid with credit card";
    }
}