namespace Ticketautomat;

public class Ticketmachine
{
    public readonly IState HasNoMoney;
    public readonly IState HasMoney;
    public readonly IState NoTicketsAvailable;
    public IState State { get; set; }
    
    public readonly List<Ticket> _tickets;
    public Ticket SelectedTicket { get; set; }
    public double Cash { get; set; }

    private IPayable _paymentStrategy;

    public void SetPaymentStrategy(IPayable strategy)
    {
        _paymentStrategy = strategy;
    }

    private Ticketmachine()
    {
        _tickets = new System.Collections.Generic.List<Ticket>()
        {
            new Ticket("Erwachsene", 4.2),
            new Ticket("Erwachsene", 4.2),
            new Ticket("Erwachsene", 4.2),
            new Ticket("Jugendliche", 3.5),
            new Ticket("Jugendliche", 3.5),
            new Ticket("Jugendliche", 3.5),
            new Ticket("Jugendliche", 3.5),
            new Ticket("Kinder", 3.1),
            new Ticket("Kinder", 3.1),
            new Ticket("Senioren", 3.4),
            new Ticket("Senioren", 3.4),
            new Ticket("Senioren", 3.4),
            new Ticket("Senioren", 3.4),
            new Ticket("Senioren", 3.4),
            new Ticket("Ermäßigt", 3.0),
            new Ticket("Ermäßigt", 3.0)
        };
        HasNoMoney = new HasNoMoney(this);
        HasMoney = new HasMoney(this);
        NoTicketsAvailable = new NoTicketsAvailable(this);
        if (_tickets.Count > 0)
        {
            State = HasNoMoney;
        }
    }

    private static Ticketmachine instance;

    public static Ticketmachine Instance
    {
        get
        {
            if (instance == null)
                instance = new Ticketmachine();
            return instance;
        }
    }
    
    public string CashIn(double cash)
    {
        return State.CashIn(cash) + " " + _paymentStrategy.Pay(cash);
    }

    public string SelectTicket(Ticket ticket)
    {
        return State.SelectTicket(ticket);
    }

    public void GetTicket()
    {
        State.GetTicket();
    }

    public void ReleaseTicket()
    {
        _tickets.Remove(SelectedTicket);
        if (_tickets.Count <= 0)
            State = NoTicketsAvailable;
        else
            State = HasNoMoney;
        Cash = 0;
    }
}