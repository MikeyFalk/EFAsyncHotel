using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Api
{
    public class AmenitiesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RoomsDTO> RoomAmmenties { get; set; }

    }
}
