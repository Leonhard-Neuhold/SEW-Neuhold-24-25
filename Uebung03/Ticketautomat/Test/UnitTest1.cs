using System.Xml;
using Ticketautomat;

namespace Test;

public class Tests
{
    private Ticketmachine _ticketmachine;

    [SetUp]
    public void Setup()
    {
        _ticketmachine = Ticketmachine.Instance;
    }

    [Test]
    public void Test()
    {
        _ticketmachine.SetPaymentStrategy(new CashPayment());
        int countBefore = _ticketmachine._tickets.Count;
        Console.WriteLine(_ticketmachine.CashIn(3.4));
        Console.WriteLine(_ticketmachine.SelectTicket(new Ticket("Senioren", 3.4)));
        Console.WriteLine(_ticketmachine.CashIn(3.4));
        _ticketmachine.GetTicket();
        int countAfter = _ticketmachine._tickets.Count;
        _ticketmachine.SetPaymentStrategy(new CreditCardPayment());
        Console.WriteLine(_ticketmachine.SelectTicket(new Ticket("Erwachsene", 4.2)));
        Console.WriteLine(_ticketmachine.CashIn(3.8));
        Console.WriteLine(_ticketmachine.CashIn(0.4));
        _ticketmachine.GetTicket();
        int countAfter2 = _ticketmachine._tickets.Count;
            
        Assert.That(countAfter, Is.EqualTo(countBefore - 1));
        Assert.That(countAfter2, Is.EqualTo(countAfter - 1));
    }
}