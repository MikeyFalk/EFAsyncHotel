using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models
{
    public class Room
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Layout { get; set; }

        /// <summary>
        /// These are the navigation properties
        /// </summary>

       public List<RoomAmenity> RoomAmenities { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }

    }
}
