namespace Backend.Data;

public partial class Hall
{
    public List<Seat> Seats { get; set; } = null!;
    public List<Showtime> Showtimes { get; set; } = null!;
}
