using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        public Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotelRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotel(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> GetHotelRooms()
        {
            throw new NotImplementedException();
        }

        public Task<HotelRoom> UpdateHotelRoom(int Id, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
