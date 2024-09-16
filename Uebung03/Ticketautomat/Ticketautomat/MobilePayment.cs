namespace Ticketautomat;

public class MobilePayment : IPayable
{
    public string Pay(double cash)
    {
        return $"Paid with the mobile phone!";
    }
}