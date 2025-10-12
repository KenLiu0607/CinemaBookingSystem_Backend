using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public int? Points { get; set; }

    public string? Level { get; set; }

    public string Password { get; set; } = null!;

    public string? AvatarFileName { get; set; }

    public string JoinDate { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
