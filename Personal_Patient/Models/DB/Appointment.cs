using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Patient.Models
{
    public class Appointment
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }

        [ForeignKey("Doctor")]
        public int doctorid { get; set; }
        public Doctor doctor { get; set; }
        [ForeignKey("Patient")]
        public int patientid { get; set; }
        public Patient patient { get; set; }
    }
}
