namespace Ticketautomat;

public class HasNoMoney : IState
{
    private readonly Ticketmachine _ticketmachine;

    public HasNoMoney(Ticketmachine ticketmachine)
    {
        _ticketmachine = ticketmachine;
    }

    public string CashIn(double cash)
    {
        _ticketmachine.Cash += cash;

        if (_ticketmachine.SelectedTicket == null)
        {
            return $"No ticket selected!";
        }
        
        if (_ticketmachine.SelectedTicket.Cost > _ticketmachine.Cash)
        {
            _ticketmachine.State = _ticketmachine.HasNoMoney;
            return $"No enough cash to buy the ticket!";
        }

        _ticketmachine.State = _ticketmachine.HasMoney;
        return $"Ticket bought!";
    }

    public string SelectTicket(Ticket ticket)
    {
        _ticketmachine.SelectedTicket = ticket;
        return $"Ticket {ticket.Name} selected!";
    }

    public void GetTicket()
    {
        
    }
}