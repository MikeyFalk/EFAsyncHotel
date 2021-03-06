﻿using EFAsyncHotel.Data;
using EFAsyncHotel.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private HotelDbContext _context;

        public AmenityRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
                
        }

       

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<AmenityDTO> GetAmenity(int Id)
        {
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {   Id = amenity.Id,
                    Name = amenity.Name

                }).FirstOrDefaultAsync(a => a.Id == Id);
                
            
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        Task<AmenityDTO> IAmenity.GetAmenity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
