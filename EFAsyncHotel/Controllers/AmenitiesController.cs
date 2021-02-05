using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFAsyncHotel.Data;
using EFAsyncHotel.Models;
using EFAsyncHotel.Models.Interfaces;
using EFAsyncHotel.Models.Api;
using Microsoft.AspNetCore.Authorization;

namespace EFAsyncHotel.Controllers
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities1
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            return Ok(await _amenity.GetAmenities());
        }

        // GET: api/Hotels1/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            AmenityDTO amenity = await _amenity.GetAmenity(id);

            return amenity;
        }

        // PUT: api/Hotels1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            var updatedAmenity = await _amenity.UpdateAmenity(id, amenity);
           
            return Ok(updatedAmenity);
        }

        // POST: api/Hotels1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            await _amenity.Create(amenity);

            return CreatedAtAction("GetHotel", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Hotels1/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);

            return NoContent();
        }
    }
}
