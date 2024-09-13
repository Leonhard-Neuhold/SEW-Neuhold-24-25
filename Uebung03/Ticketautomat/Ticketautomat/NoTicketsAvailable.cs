namespace Ticketautomat;

public class NoTicketsAvailable : IState
{
    private readonly Ticketmachine _ticketmachine;

    public NoTicketsAvailable(Ticketmachine ticketmachine)
    {
        _ticketmachine = ticketmachine;
    }

    public void CashIn(double cash)
    {
        
    }

    public void SelectTicket(Ticket ticket)
    {
        
    }

    public Ticket GetTicket(Ticket ticket)
    {
        return ticket;
    }
}