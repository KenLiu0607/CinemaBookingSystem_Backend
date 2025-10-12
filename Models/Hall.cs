using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Hall
{
    public int Id { get; set; }

    public int SeatLayoutId { get; set; }

    public string HallName { get; set; } = null!;

    public string? Description { get; set; }
}
