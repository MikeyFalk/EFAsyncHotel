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

namespace EFAsyncHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
            return Ok(await _hotelRoom.GetHotelRooms());
        }

        // GET: api/Hotels/{hotelId}/Rooms
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomId)
        {

            HotelRoom hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomId);

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelid, int roomId, HotelRoom hotelRoom)
        {
            if (hotelid != hotelRoom.HotelId && roomId != hotelRoom.RoomID)
            {
                return BadRequest();
            }

            var upDatedHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelid, roomId, hotelRoom);

            return Ok(upDatedHotelRoom);



        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{HotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {

            {
                await _hotelRoom.Create(hotelRoom);

                return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
            }

        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{hotel/Id}/Rooms/{roomNumber")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomId)
        {
            await _hotelRoom.DeleteHotelRoom(hotelId, roomId);


            return NoContent();
        }

    }   
}
