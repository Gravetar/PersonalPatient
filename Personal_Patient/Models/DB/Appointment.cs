using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Patient.Models
{
    public class Appointment
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }

        public int id_doctor { get; set; }
        public int id_patient { get; set; }
        Patient patient { get; set; }
        Doctor doctor { get; set; }
    }
}
