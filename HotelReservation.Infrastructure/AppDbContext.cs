using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerReservation> CustomerReservations { get; set; }
        public DbSet<HotelRoomEntity> HotelRooms { get; set; }
        public DbSet<HotelRoomReservation> HotelRoomReservations { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<PricePlanEntity> PricePlans { get; set; }
        public DbSet<DailyPriceEntity> DailyPrices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerReservation>()
                .HasKey(cr => new { cr.CustomerId, cr.ReservationId });

            modelBuilder.Entity<HotelRoomReservation>()
                .HasKey(cr => new { cr.HotelRoomId, cr.ReservationId });

            modelBuilder.Entity<CustomerReservation>()
                .HasOne(cr => cr.Customer)
                .WithMany(c => c.CustomerReservation)
                .HasForeignKey(cr => cr.CustomerId);

            modelBuilder.Entity<CustomerReservation>()
                .HasOne(cr => cr.Reservation)
                .WithMany(r => r.CustomerReservations)
                .HasForeignKey(cr => cr.ReservationId);

            modelBuilder.Entity<HotelRoomReservation>()
                .HasOne(hrr => hrr.HotelRoom)
                .WithMany(hr => hr.HotelRoomReservations)
                .HasForeignKey(hrr => hrr.HotelRoomId);

            modelBuilder.Entity<HotelRoomReservation>()
                .HasOne(hrr => hrr.Reservation)
                .WithMany(hr => hr.HotelRoomReservations)
                .HasForeignKey(hrr => hrr.ReservationId);

            modelBuilder.Entity<PricePlanEntity>()
                .HasMany(pp => pp.DailyPrices)
                .WithOne(pr => pr.PricePlan)
                .HasForeignKey(dp => dp.PricePlanId);

            modelBuilder.Entity<PricePlanEntity>()
                .HasMany(pp => pp.HotelRooms)
                .WithOne(pr => pr.PricePlanEntity)
                .HasForeignKey(hr => hr.PricePlanId);
        }

    }
}
