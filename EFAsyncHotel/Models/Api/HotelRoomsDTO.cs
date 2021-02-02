using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Api
{
    public class HotelRoomsDTO
    {
        public string RoomNumber { get; set; }
        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }
        
        public int RoomId { get; set; }

    }
}
