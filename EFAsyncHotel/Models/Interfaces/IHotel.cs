using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces
{
    interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        Task<Hotel> GetHotel(int Id);

        Task<List<Hotel>> GetHotels();
        Task<Hotel> UpdateHotel(int Id, Hotel hotel);

        Task DeleteHotel(int Id);
            
    }
}
