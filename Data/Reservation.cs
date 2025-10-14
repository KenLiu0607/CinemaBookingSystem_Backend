using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class Reservation
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int ShowtimeId { get; set; }

    public int? SeatId { get; set; }

    public DateOnly ReservationAt { get; set; }
}
