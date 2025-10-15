using System;
using System.Collections.Generic;

namespace Backend.Data;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string CastInfo { get; set; } = null!;

    public string Rating { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}
