using Backend.Data;

namespace Backend.Models
{
    public class BookingViewModel
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string? CastInfo { get; set; }
        public string? Rating { get; set; }
        public string? Genre { get; set; }
        public string? FileName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public List<string> RangeDate
        {
            get
            {
                var dates = new List<string>();
                if (StartDate.HasValue && EndDate.HasValue && StartDate <= EndDate)
                {
                    for (var date = StartDate.Value; date <= EndDate.Value; date = date.AddDays(1))
                    {
                        dates.Add(date.ToString("yyyy-MM-dd"));
                    }
                }
                return dates;
            }
        }

        public List<Hall> Halls { get; set; } = null!;
        public List<Showtime> ShowTimes { get; set; } = null!;
        public List<Seat> Seats { get; set; } = null!;
    }
}
