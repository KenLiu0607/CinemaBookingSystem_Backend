using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Director { get; set; }

    public string? CastInfo { get; set; }

    public string? Rating { get; set; }

    public string? Genre { get; set; }

    public string? FileName { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}
