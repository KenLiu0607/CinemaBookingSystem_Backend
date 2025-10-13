using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int? SeatReservedId { get; set; }

    public DateTime ReservedAt { get; set; }
}
