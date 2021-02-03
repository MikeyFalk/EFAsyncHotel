using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using EFAsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using EFAsyncHotel.Models;
using System.Threading.Tasks;
using Xunit;

namespace HotelTests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly HotelDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new HotelDbContext(
                new DbContextOptionsBuilder<HotelDbContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel
            {
                Name = "Test",
                City = "Vancouver",
                State = "BC",
                Address = "9876 Robb St.",
                PhoneNumber = "123-456-7890"
            };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, hotel.Id);
            return hotel;
        }

        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity
            {
                Name = "24 hour room service"
            };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.Id);
            return amenity;
        }

    }
}
