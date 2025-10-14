using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class ShowtimeSlot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly Time { get; set; }
}
