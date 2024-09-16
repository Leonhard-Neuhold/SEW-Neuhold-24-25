namespace Ticketautomat;

public class HasMoney : IState
{
    private readonly Ticketmachine _ticketmachine;

    public HasMoney(Ticketmachine ticketmachine)
    {
        _ticketmachine = ticketmachine;
    }

    public string CashIn(double cash)
    {
        return $"Already has enough Cash!";
    }

    public string SelectTicket(Ticket ticket)
    {
        return $"Ticket already selected!";
    }

    public void GetTicket()
    {
        _ticketmachine.ReleaseTicket();
        _ticketmachine.SelectedTicket = null;
    }
}