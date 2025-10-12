using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Guest
{
    public int Id { get; set; }

    public string ContactInfo { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
