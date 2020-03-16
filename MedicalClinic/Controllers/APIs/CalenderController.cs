using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalClinic.Data;
using MedicalClinic.Models;

namespace MedicalClinic.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalenderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Calender
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            return await _context.Booking.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking(int id)
        {
            var booking = await _context.Booking.Include(x => x.Doctor)
                .Include(x => x.Patient).Where( x => x.PatientId == id).ToListAsync();

            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        // GET: api/GetDayAvailableDoctor
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<DayOfWeek>>> GetDayAvailableDoctor(int id)
        {
            DayOfWeek[] days = {
            };
            var doctorDays = await _context.DoctorDays.Include(x => x.Doctor)
                 .Where(x => x.DoctorId == id).ToListAsync();
            foreach (DoctorDays item in doctorDays)
            {
                days.Append(item.Day);
            }
            if (doctorDays == null)
            {
                return NotFound();
            }
            return days;
        }

        // GET: api/GetTimeBooking
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<DateTime>>> GetTimeBooking(int id, DateTime date)
        {
            DateTime[] times = {
            };
            var booking = await _context.Booking.Include(x => x.Doctor)
                 .Where(x => x.DoctorId == id && x.ReservationDateTime.Day == date.Day).ToListAsync();
            foreach (Booking item in booking)
            {
                times.Append(item.ReservationDateTime);
            }
            if (booking == null)
            {
                return NotFound();
            }
            return times;
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
