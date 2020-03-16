using System;
using System.Collections.Generic;
using System.Text;
using MedicalClinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Booking { set; get; }
        public DbSet<Doctor> Doctor { set; get; }
        public DbSet<Patient> Patient { set; get; }
        public DbSet<DoctorDays> DoctorDays { set; get; }
    }
}
