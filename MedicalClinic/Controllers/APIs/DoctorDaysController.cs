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
    public class DoctorDaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DoctorDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDays>>> GetDoctorDays()
        {
            return await _context.DoctorDays.ToListAsync();
        }

    }
}
