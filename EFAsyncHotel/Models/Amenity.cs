﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models
{
    public class Amenity
    {
    public int Id { get; set;  }

        [Required]
    public string Name { get; set; }

    public List<RoomAmenity> RoomAmenities { get; set; }




    }

}
