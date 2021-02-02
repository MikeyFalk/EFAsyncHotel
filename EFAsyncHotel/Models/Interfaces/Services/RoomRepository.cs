using EFAsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int Id)
        {
            return await _context.Rooms
                .Include(r => r.RoomAmenities)
                 .ThenInclude(a => a.Amenity)
                  .FirstOrDefaultAsync(r => r.Id == Id);
        
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
                .Include(r => r.RoomAmenities)
                 .ThenInclude(a => a.Amenity)
                   .ToListAsync();           
                
        }

        public async Task<Room> UpdateRoom(int Id, Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();



        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomId && x.AmenityId == amenityId);

            _context.Entry(result).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
