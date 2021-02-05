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
using Microsoft.AspNetCore.Authorization;

namespace EFAsyncHotel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        // GET: api/Rooms/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _room.GetRoom(id);

            return room;
           
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [Authorize(Roles = "District Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }
        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "District Manager")]
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
           
            await _room.Create(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);

            return NoContent();
        }

        //POST: api/Rooms/5/7
        [Authorize(Roles = "District Manager")]
        [Authorize(Roles = "Property Manager")]
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();

        }


        //DELETE: api/Rooms/5/7
        [Authorize(Roles = "District Manager")]
        [HttpDelete]
        [Route("{roomId}/Amenity{amenityId}")]
        public async Task<IActionResult> DeleteAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenityFromRoom(roomId, amenityId);
            return NoContent();
        }

       
    }
}
