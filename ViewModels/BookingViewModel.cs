using Backend.Data;

namespace Backend.ViewModels
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
        public List<ShowtimeSlot> ShowtimeSlots { get; set; } = null!;
        //public int? HallId { get; set; }
        //public int? SeatLayoutId { get; set; }
        //public string? HallName { get; set; }
        //public string? HallDescription { get; set; }
        //public int? SeatId { get; set; }
        //public int? RowNumber { get; set; }
        //public int? ColNumber { get; set; }
        //public string? Label { get; set; }
        //public string? Type { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsAisle { get; set; }
        //public int? ShowtimeId { get; set; }
        //public int? ShowtimeSlotId { get; set; }
        //public string? ShowtimeSlotName { get; set; }
        //public TimeOnly? ShowtimeSlotTime { get; set; }
        //public int? ReservationId { get; set; }
        //public int? TicketId { get; set; }
        //public DateOnly? ReservationAt { get; set; }
        //public string? SeatStatus { get; set; }
    }
}
