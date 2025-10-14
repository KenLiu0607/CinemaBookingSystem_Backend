namespace Backend.Models.ViewModels
{
    public class BookingDTO
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public string? CastInfo { get; set; }
        public string? Rating { get; set; }
        public string? Genre { get; set; }
        public string? FileName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int HallId { get; set; }
        public int SeatLayoutId { get; set; }
        public string? HallName { get; set; }
        public string? HallDescription { get; set; }
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        public string? Label { get; set; }
        public string? Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsAisle { get; set; }
        public int ShowtimeId { get; set; }
        public int ShowtimeSlotId { get; set; }
        public string? ShowtimeSlotName { get; set; }
        public TimeOnly ShowtimeSlotTime { get; set; }
        public int? ReservationId { get; set; }
        public int? TicketId { get; set; }
        public DateOnly? ReservationAt { get; set; }
        public string? SeatStatus { get; set; }
    }
}
