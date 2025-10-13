using System;
using System.Collections.Generic;
using Backend.Models;
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

    public virtual DbSet<SeatLayout> SeatLayouts { get; set; }

    public virtual DbSet<SeatLayoutDetail> SeatLayoutDetails { get; set; }

    public virtual DbSet<SeatReserved> SeatReserveds { get; set; }

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
                .HasColumnName("description");
            entity.Property(e => e.HallName)
                .HasMaxLength(50)
                .HasColumnName("hall_name");
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
                .HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
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
            entity.Property(e => e.CastInfo).HasColumnName("cast_info");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("file_name");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            entity.Property(e => e.Rating)
                .HasMaxLength(20)
                .HasColumnName("rating");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reservation_pkey");

            entity.ToTable("reservation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ReservedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reserved_at");
            entity.Property(e => e.SeatReservedId).HasColumnName("seat_reserved_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
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
                .HasColumnName("description");
            entity.Property(e => e.LayoutName)
                .HasMaxLength(50)
                .HasColumnName("layout_name");
            entity.Property(e => e.RowsCount).HasColumnName("rows_count");
        });

        modelBuilder.Entity<SeatLayoutDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_layout_detail_pkey");

            entity.ToTable("seat_layout_detail");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ColumnNumber).HasColumnName("column_number");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAisle)
                .HasDefaultValue(false)
                .HasColumnName("is_aisle");
            entity.Property(e => e.RowNumber).HasColumnName("row_number");
            entity.Property(e => e.SeatLabel)
                .HasMaxLength(10)
                .HasColumnName("seat_label");
            entity.Property(e => e.SeatLayoutId).HasColumnName("seat_layout_id");
            entity.Property(e => e.SeatType)
                .HasMaxLength(20)
                .HasDefaultValueSql("'normal'::character varying")
                .HasColumnName("seat_type");
        });

        modelBuilder.Entity<SeatReserved>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_pkey");

            entity.ToTable("seat_reserved");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IsCancelled)
                .HasDefaultValue(false)
                .HasColumnName("is_cancelled");
            entity.Property(e => e.ReservedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reserved_at");
            entity.Property(e => e.SeatLayoutDetailId).HasColumnName("seat_layout_detail_id");
            entity.Property(e => e.ShowtimeId)
                .HasDefaultValue(0)
                .HasColumnName("showtime_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Showtime_pkey");

            entity.ToTable("showtime");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.ShowtimeSlotId).HasColumnName("showtime_slot_id");
        });

        modelBuilder.Entity<ShowtimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showtime_slot_pkey");

            entity.ToTable("showtime_slot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SlotName)
                .HasMaxLength(10)
                .HasDefaultValueSql("'早場'::character varying")
                .HasColumnName("slot_name");
            entity.Property(e => e.SlotTime).HasColumnName("slot_time");
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
                .HasColumnName("refund_reason");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TicketType)
                .HasMaxLength(20)
                .HasColumnName("ticket_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
