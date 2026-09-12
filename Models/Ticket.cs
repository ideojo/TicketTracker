using System.ComponentModel.DataAnnotations;

namespace TicketTracker.Models;

public enum TicketStatus
{
    New,
    InProgress,
    Resolved
}

public class Ticket
{
    public int Id { get; set; }
    [Required(ErrorMessage = "A ticket needs a title.")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.New;
    public string AssignedTo { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
}
