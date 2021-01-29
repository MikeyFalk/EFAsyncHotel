using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models
{
    public class HotelRoom
    {

        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }

        public decimal Rate { get; set; }
        public byte PetFriendly { get; set; }

       public List<Hotel> Hotels {get; set;}
       
        public List<Room> Rooms { get; set; }
    }
}
