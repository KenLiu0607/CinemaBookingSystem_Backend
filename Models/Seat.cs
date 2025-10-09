using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Seat
{
    public int Id { get; set; }

    public int HallId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public string Status { get; set; } = null!;
}
