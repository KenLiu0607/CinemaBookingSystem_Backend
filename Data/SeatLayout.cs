using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class SeatLayout
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int RowsCount { get; set; }

    public int ColumnsCount { get; set; }
}
