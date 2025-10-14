using Backend.Data;
using Backend.Models.ViewModels;
using Backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BookingService
    {
        private readonly CinemaDbContext _context;

        public BookingService(CinemaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得完整的電影-廳院-座位-場次-訂位資訊
        /// </summary>
        public async Task<List<BookingDTO>> GetBookingDTOAsync()
        {
            var query =
                from m in _context.Movies.AsNoTracking()
                join st in _context.Showtimes.AsNoTracking() on m.Id equals st.MovieId into movieShowtime
                from st in movieShowtime.DefaultIfEmpty()
                join sts in _context.ShowtimeSlots.AsNoTracking() on st.ShowtimeSlotId equals sts.Id into showtimeSlot
                from sts in showtimeSlot.DefaultIfEmpty()
                join h in _context.Halls.AsNoTracking() on st.HallId equals h.Id into hallJoin
                from h in hallJoin.DefaultIfEmpty()
                join s in _context.Seats.AsNoTracking() on h.SeatLayoutId equals s.SeatLayoutId into seatJoin
                from s in seatJoin.DefaultIfEmpty()
                join res in _context.Reservations.AsNoTracking()
                                on new { ShowtimeId = (int?)st.Id, SeatId = (int?)s.Id }
                                equals new { ShowtimeId = (int?)res.ShowtimeId, SeatId = (int?)res.SeatId } into resJoin
                from res in resJoin.DefaultIfEmpty()
                select new BookingDTO
                {
                    MovieId = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Director = m.Director,
                    CastInfo = m.CastInfo,
                    Rating = m.Rating,
                    Genre = m.Genre,
                    FileName = m.FileName,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,

                    HallId = h.Id,
                    SeatLayoutId = h.SeatLayoutId,
                    HallName = h.Name,
                    HallDescription = h.Description,

                    SeatId = s.Id,
                    RowNumber = s.RowNumber,
                    ColNumber = s.ColNumber,
                    Label = s.Label,
                    Type = s.Type,
                    IsActive = s.IsActive,
                    IsAisle = s.IsAisle,

                    ShowtimeId = st.Id,
                    ShowtimeSlotId = sts.Id,
                    ShowtimeSlotName = sts.Name,
                    ShowtimeSlotTime = sts.Time,

                    ReservationId = res.Id,
                    TicketId = res.TicketId,
                    ReservationAt = res.ReservationAt,

                    SeatStatus = res.TicketId != null ? "已售出"
                               : s.IsActive ? "開放預售"
                               : "不開放"
                };

            return await query.ToListAsync();
        }

        public async Task<List<BookingViewModel>> GetBookingViewModelAsync()
        {
            List<BookingDTO> data = await GetBookingDTOAsync();

            var result = data.GroupBy(g => g.MovieId)
                .Select(s =>
                {
                    BookingViewModel bookVW = new BookingViewModel();
                    var movie = s.FirstOrDefault();
                    if (movie != null)
                    {
                        bookVW.MovieId = movie.MovieId;
                        bookVW.Title = movie.Title;
                        bookVW.Description = movie.Description;
                        bookVW.Director = movie.Director;
                        bookVW.CastInfo = movie.CastInfo;
                        bookVW.Rating = movie.Rating;
                        bookVW.Genre = movie.Genre;
                        bookVW.FileName = movie.FileName;
                        bookVW.StartDate = movie.StartDate;
                        bookVW.EndDate = movie.EndDate;
                    }
                    var halls = s
                        .Select(h => new Hall
                        {
                            Id = h.HallId,
                            SeatLayoutId = h.SeatLayoutId,
                            Name = h.HallName = null!,
                            Description = h.HallDescription
                        })
                        .DistinctBy(d => d.Id)
                        .OrderBy(o => o.Id)
                        .ToList();
                    var showtimeSlots = s
                        .Select(st => new ShowtimeSlot
                        {
                            Id = st.ShowtimeSlotId,
                            Name = st.ShowtimeSlotName = null!,
                            Time = st.ShowtimeSlotTime
                        })
                        .DistinctBy(d => d.Id)
                        .OrderBy(o => o.Time)
                        .ToList();
                    bookVW.Halls = halls;
                    bookVW.ShowtimeSlots = showtimeSlots;
                    return bookVW;
                }).ToList();

            return result;
        }
    }
}
