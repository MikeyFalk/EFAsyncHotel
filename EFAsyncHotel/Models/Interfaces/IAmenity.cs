using EFAsyncHotel.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces
{
    public interface IAmenity
    {
       Task<Amenity> Create(Amenity amenity);
       
        Task<List<Amenity>> GetAmenities();

        Task<AmenityDTO> GetAmenity(int id);

        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        Task DeleteAmenity(int id);
    }
}
