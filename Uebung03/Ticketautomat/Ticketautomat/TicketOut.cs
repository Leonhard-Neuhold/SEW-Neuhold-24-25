namespace Ticketautomat;

public class TicketOut : IState
{
    private readonly Ticketmachine _ticketmachine;

    public TicketOut(Ticketmachine ticketmachine)
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