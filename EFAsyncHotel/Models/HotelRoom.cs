using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFAsyncHotel.Models
{
    public class HotelRoom
    {

        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }

        public decimal Rate { get; set; }
        public byte PetFriendly { get; set; }
        /// <summary>
        /// Navigation properties
        /// </summary>
       public Hotel Hotel {get; set;}
       
        public Room Room { get; set; }
    }
}
