using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces
{
    public interface IHotelRoom

    {
        Task <HotelRoom> Create(HotelRoom hotelRoom);
        Task <HotelRoom> GetHotelRoom(int hotelId, int roomId);
        Task<List <HotelRoom>> GetHotelRooms();

        Task <HotelRoom> UpdateHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomId);



    }
}
