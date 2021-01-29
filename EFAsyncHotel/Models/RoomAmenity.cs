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

        public Room Room { get; set; }
        public Amenity Amenity { get; set; }

        public List<Amenity> Amenities { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
