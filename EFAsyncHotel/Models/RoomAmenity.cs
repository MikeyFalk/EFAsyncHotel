using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models
{
    public class RoomAmenity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        /// <summary>
        /// These are navigation keys
        /// </summary>
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }

    }
}
