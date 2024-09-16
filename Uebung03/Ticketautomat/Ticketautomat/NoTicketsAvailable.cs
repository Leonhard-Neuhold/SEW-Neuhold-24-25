namespace Ticketautomat;

public class NoTicketsAvailable : IState
{
    private readonly Ticketmachine _ticketmachine;

    public NoTicketsAvailable(Ticketmachine ticketmachine)
    {
        _ticketmachine = ticketmachine;
    }

    public string CashIn(double cash)
    {
        return $"Already inserted cash!";
    }

    public string SelectTicket(Ticket ticket)
    {
        return $"Already selected ticket!";
    }

    public void GetTicket()
    {
        
    }
}