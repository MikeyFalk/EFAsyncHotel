using EFAsyncHotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private HotelDbContext _context;

        public HotelRoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        public async Task DeleteHotelRoom(int hotelId, int roomId)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomId);
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomId)
        {
             var hotelRoom = await _context.HotelRooms.Where(x => x.HotelId == hotelId && x.RoomNumber == roomId).FirstOrDefaultAsync();
            
            return hotelRoom;
        }

        
        public async Task<List<HotelRoom>>GetHotelRooms() 
        {
            var hotelRooms = await _context.HotelRooms.ToListAsync();
            return hotelRooms;
        }

        public async Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        

        

        
       
    }
}
