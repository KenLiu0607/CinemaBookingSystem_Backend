using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class ShowtimeSlot
{
    public int Id { get; set; }

    public string SlotName { get; set; } = null!;

    public TimeOnly SlotTime { get; set; }
}
