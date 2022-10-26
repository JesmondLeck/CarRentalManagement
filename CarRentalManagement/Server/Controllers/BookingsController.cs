using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {   
        //Refactored 
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public BookingsController(ApplicationDbContext context)
        public BookingsController(IUnitOfWork unitOfWork)
        {   
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {   
            //Refactored
            //return await _context.Bookings.ToListAsync();
            var bookings = await _unitOfWork.Bookings.GetAll();
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Booking>> GetBooking(int id)
        public async Task<IActionResult> GetBooking(int id)
        {
            //Refactored
            //var booking = await _context.Bookings.FindAsync(id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(booking);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        { 
            if (id != booking.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(booking).State = EntityState.Modified;
            _unitOfWork.Bookings.Update(booking);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!BookingExists(id))
                if (!await BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            //Refactored
            //_context.Bookings.Add(booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Insert(booking);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            //Refactored
            //var booking = await _context.Bookings.FindAsync(id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Bookings.Remove(booking);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool BookingExists(int id)
        private async Task<bool> BookingExists(int id)
        {
            //Refactored
            //return _context.Bookings.Any(e => e.Id == id);
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            return booking != null;
        }
    }
}
