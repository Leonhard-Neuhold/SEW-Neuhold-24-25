namespace Ticketautomat;

public interface IState
{
    void CashIn(double cash);
    void SelectTicket(Ticket ticket);
    Ticket GetTicket(Ticket ticket);
}