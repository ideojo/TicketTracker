using TicketTracker.Models;

namespace TicketTracker.Services;

/// <summary>
/// Holds tickets in memory for the lifetime of the application.
/// Registered as a singleton, so every user of the app sees the same list.
/// </summary>
public class TicketService
{
    private readonly List<Ticket> _tickets = new();
    private int _nextId = 1;

    public TicketService()
    {
        // Seed a couple of rows so the page has something to show on first run.
        Add(new Ticket
        {
            Title = "Printer offline in Room 214",
            Description = "HP LaserJet stopped responding after the network change.",
            AssignedTo = "Sachin"
        });

        Add(new Ticket
        {
            Title = "New hire account setup",
            Description = "Account created; needs initial credentials and group membership.",
            AssignedTo = "Help Desk"
        });
    }

    public IReadOnlyList<Ticket> GetAll() =>
        _tickets.OrderByDescending(t => t.Id).ToList();

    public Ticket? GetById(int id) =>
        _tickets.FirstOrDefault(t => t.Id == id);

    public void Add(Ticket ticket)
    {
        ticket.Id = _nextId++;
        ticket.CreatedAt = DateTime.Now;
        _tickets.Add(ticket);
    }

    public void UpdateStatus(int id, TicketStatus status)
    {
        var ticket = GetById(id);

        if (ticket is not null)
        {
            ticket.Status = status;
        }
    }
}
