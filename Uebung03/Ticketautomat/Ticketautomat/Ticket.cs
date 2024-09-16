namespace Ticketautomat;

public class Ticket
{
    public string Name { get; set; }
    public double Cost { get; set; }

    public Ticket(string name, double cost)
    {
        Name = name;
        Cost = cost;
    }

    public override bool Equals(object? obj)
    {
        return Equals((Ticket)obj);
    }
    
    public bool Equals(Ticket? ticket)
    {
        return this.Name == ticket.Name && this.Cost == ticket.Cost;
    }
}