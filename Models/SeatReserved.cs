using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class SeatReserved
{
    public int Id { get; set; }

    public int SeatLayoutDetailId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ReservedAt { get; set; }

    public bool IsCancelled { get; set; }

    public int ShowtimeId { get; set; }
}
