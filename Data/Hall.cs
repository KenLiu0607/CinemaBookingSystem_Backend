using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class Hall
{
    public int Id { get; set; }

    public int SeatLayoutId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
