namespace Ticketautomat;

public class HasMoney : IState
{
    private readonly Ticketmachine _ticketmachine;

    public HasMoney(Ticketmachine ticketmachine)
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