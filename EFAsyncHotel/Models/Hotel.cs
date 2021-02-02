using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFAsyncHotel.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        /// <summary>
        /// Navigation properties
        /// </summary>
        public List<HotelRoom> HotelRoom { get; set; }

    }
}
