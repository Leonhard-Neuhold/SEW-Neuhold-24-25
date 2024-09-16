namespace Ticketautomat;

public interface IState
{
    string CashIn(double cash);
    string SelectTicket(Ticket ticket);
    void GetTicket();
}