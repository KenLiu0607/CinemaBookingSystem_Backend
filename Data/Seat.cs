using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class Seat
{
    public int Id { get; set; }

    public int SeatLayoutId { get; set; }

    public int RowNumber { get; set; }

    public int ColNumber { get; set; }

    public string Label { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsAisle { get; set; }
}
