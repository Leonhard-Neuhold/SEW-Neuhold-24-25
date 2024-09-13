namespace Ticketautomat;

public class HasNoMoney : IState
{
    private readonly Ticketmachine _ticketmachine;

    public HasNoMoney(Ticketmachine ticketmachine)
    {
        _ticketmachine = ticketmachine;
    }

    public void CashIn(double cash)
    {
        
        _ticketmachine.State = _ticketmachine.HasMoney;
    }

    public void SelectTicket(Ticket ticket)
    {
        
    }

    public Ticket GetTicket(Ticket ticket)
    {
        return ticket;
    }
}