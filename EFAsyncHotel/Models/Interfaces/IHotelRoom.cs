using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces
{
    public interface IHotelRoom

    {
        Task <HotelRoom> Create(HotelRoom hotelRoom);
        Task <HotelRoom> GetHotel(int Id);
        Task <HotelRoom> GetHotelRooms();

        Task <HotelRoom> UpdateHotelRoom(int Id, HotelRoom hotelRoom);
        Task DeleteHotelRoom(int Id);



    }
}
