using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatLayout> SeatLayouts { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<ShowtimeSlot> ShowtimeSlots { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-lingering-sea-a13d2so4.ap-southeast-1.aws.neon.tech; Database=Cinema; Username=neondb_owner; Password=npg_Ch5bmOUWf0nK; SSL Mode=VerifyFull; Channel Binding=Require;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("guest_pkey");

            entity.ToTable("guest");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(100)
                .HasColumnName("contact_info");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hall_pkey");

            entity.ToTable("hall");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SeatLayoutId).HasColumnName("seat_layout_id");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Member_pkey");

            entity.ToTable("member");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AvatarFileName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("avatar_file_name ");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(100)
                .HasColumnName("contact_info");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at ");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.JoinDate)
                .HasMaxLength(255)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("join_date");
            entity.Property(e => e.Level)
                .HasMaxLength(1)
                .HasDefaultValueSql("'C'::character varying")
                .HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Points)
                .HasDefaultValue(0)
                .HasColumnName("points");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at ");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Movie_pkey");

            entity.ToTable("movie");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CastInfo)
                .HasDefaultValueSql("''::text")
                .HasColumnName("cast_info");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''::text")
                .HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("director");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("end_date");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasDefaultValueSql("'愛情'::character varying")
                .HasColumnName("genre");
            entity.Property(e => e.Rating)
                .HasMaxLength(20)
                .HasDefaultValueSql("'保護級'::character varying")
                .HasColumnName("rating");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservation_pkey");

            entity.ToTable("reservation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ReservationAt)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("reservation_at");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_layout_detail_pkey");

            entity.ToTable("seat");

            entity.HasIndex(e => e.SeatLayoutId, "idx_seat_layout_20251014");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ColNumber).HasColumnName("col_number");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAisle)
                .HasDefaultValue(false)
                .HasColumnName("is_aisle");
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .HasColumnName("label");
            entity.Property(e => e.RowNumber).HasColumnName("row_number");
            entity.Property(e => e.SeatLayoutId).HasColumnName("seat_layout_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasDefaultValueSql("'normal'::character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<SeatLayout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_layout_pkey");

            entity.ToTable("seat_layout");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ColumnsCount).HasColumnName("columns_count");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RowsCount).HasColumnName("rows_count");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Showtime_pkey");

            entity.ToTable("showtime");

            entity.HasIndex(e => new { e.HallId, e.MovieId }, "idx_hall_movie_20251014");

            entity.HasIndex(e => e.MovieId, "idx_movie_20251014");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.ShowtimeSlotId).HasColumnName("showtime_slot_id");
        });

        modelBuilder.Entity<ShowtimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showtime_slot_pkey");

            entity.ToTable("showtime_slot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasDefaultValueSql("'早場'::character varying")
                .HasColumnName("name");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("CURRENT_TIME")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Ticket_pkey");

            entity.ToTable("ticket");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.IsCancelled)
                .HasDefaultValue(false)
                .HasColumnName("is_cancelled");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Price)
                .HasPrecision(8, 2)
                .HasColumnName("price");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(500)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("refund_reason");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .HasDefaultValueSql("'全票'::character varying")
                .HasColumnName("ticket_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
