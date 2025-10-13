using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public string? RefundReason { get; set; }

    public string TicketType { get; set; } = null!;

    public int? MemberId { get; set; }

    public int? GuestId { get; set; }

    public bool IsCancelled { get; set; }
}
