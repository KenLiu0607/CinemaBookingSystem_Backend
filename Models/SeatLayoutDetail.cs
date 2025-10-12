using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class SeatLayoutDetail
{
    public int Id { get; set; }

    public int SeatLayoutId { get; set; }

    public int RowNumber { get; set; }

    public int ColumnNumber { get; set; }

    public string SeatLabel { get; set; } = null!;

    public string? SeatType { get; set; }

    public bool? IsActive { get; set; }

    public bool IsAisle { get; set; }
}
