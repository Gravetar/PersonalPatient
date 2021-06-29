using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Personal_Patient.Models
{
    public class PersonalPatientContext : DbContext
    {
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Doctor> doctors { get; set; }

        public PersonalPatientContext(DbContextOptions<PersonalPatientContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
