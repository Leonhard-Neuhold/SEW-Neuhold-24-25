namespace Ticketautomat;

public class CashPayment : IPayable
{
    public string Pay(double cash)
    {
        return $"Paid with cash!";
    }
}