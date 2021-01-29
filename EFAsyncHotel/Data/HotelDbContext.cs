using EFAsyncHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Grand Pacific", City = "San Francisco", State = "CA", Address = "123 42nd Ave" },
                new Hotel { Id = 2, Name = "Mountain View", City = "Denver", State = "CO", Address = "5678 Rockies Rd" },
                new Hotel { Id = 3, Name = "Lake Side", City = "Tahoe City", State = "CA", Address = "9283 Lakeview Ln"}
                );

            modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Snore Fest", Layout = 1 },
            new Room { Id = 2, Name = "Sir Snooze Alot", Layout = 2 },
            new Room { Id = 3, Name = "Shut Eye", Layout = 3 }

            );
            modelBuilder.Entity<Amenity>().HasData(

                new Amenity { Id = 1, Name = "Microwave" },
                new Amenity { Id = 2, Name = "Mini Bar" },
                new Amenity { Id = 3, Name = "A / C" }

                );
            modelBuilder.Entity<RoomAmenity>().HasKey(

                roomAmenity => new { roomAmenity.RoomId, roomAmenity.AmenityId }
                );
            modelBuilder.Entity<HotelRoom>().HasKey(

                hotelRoom => new { hotelRoom.HotelID, hotelRoom.RoomID }
                );
             
             
        }

        // Data models we are using

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


    }
}
