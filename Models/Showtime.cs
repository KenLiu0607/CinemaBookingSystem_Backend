using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Showtime
{
    public int Id { get; set; }

    public int HallId { get; set; }

    public int MovieId { get; set; }

    public int ShowtimeSlotId { get; set; }

    public DateOnly? Date { get; set; }
}
