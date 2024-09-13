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
}