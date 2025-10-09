using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Hall
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public TimeOnly? Opentime { get; set; }
}
