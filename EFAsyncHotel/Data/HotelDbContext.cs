using EFAsyncHotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>

    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomAmenity>().HasKey(

                roomAmenity => new { roomAmenity.RoomId, roomAmenity.AmenityId }
                );
            modelBuilder.Entity<HotelRoom>().HasKey(

                hotelRoom => new { hotelRoom.HotelId, hotelRoom.RoomID }
                );

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
            SeedRole(modelBuilder, "District Manager", "create","update","delete");
            SeedRole(modelBuilder, "Property Manager", "create", "update");
            SeedRole(modelBuilder, "Agent", "create");
            SeedRole(modelBuilder, "Guest User");
            
             
             
        }

        // Data models we are using

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


        private int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
                {
                    Id = roleName.ToLower(),
                    Name = roleName,
                    NormalizedName = roleName.ToUpper(),
                    ConcurrencyStamp = Guid.Empty.ToString()
                };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            //this seeds the permissions for each group
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", //This could be potato but needs to match whats in startup.cs
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
            
        }
        


    }
}
