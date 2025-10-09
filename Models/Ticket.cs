using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int ShowtimeId { get; set; }

    public int SeatId { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public string? RefundReason { get; set; }

    public string TicketType { get; set; } = null!;
}
