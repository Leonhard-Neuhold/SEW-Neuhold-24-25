namespace Ticketautomat;

public class Ticketmachine
{
    public readonly IState HasNoMoney;
    public readonly IState HasMoney;
    public readonly IState TicketOut;
    public readonly IState NoTicketsAvailable;
    public IState State { get; set; }
    
    private List<Ticket> _tickets;
    private Ticket _selectedTicket;

    public Ticketmachine(List<Ticket> tickets)
    {
        _tickets = tickets;
        HasNoMoney = new HasNoMoney(this);
        HasMoney = new HasMoney(this);
        TicketOut = new TicketOut(this);
        NoTicketsAvailable = new NoTicketsAvailable(this);
        if (_tickets.Count > 0)
        {
            State = HasNoMoney;
        }
    }

    public void CashIn(double cash)
    {
        State.CashIn(cash);
    }

    public void SelectTicket(Ticket ticket)
    {
        State.SelectTicket(ticket);
    }

    public void GetTicket(Ticket ticket)
    {
        State.GetTicket(ticket);
    }

    public Ticket ReleaseTicket()
    {
        _tickets.Remove(_selectedTicket);
        return _selectedTicket;
    }
}