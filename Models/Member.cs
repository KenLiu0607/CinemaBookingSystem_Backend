using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public int? Points { get; set; }

    public string? Level { get; set; }
}
