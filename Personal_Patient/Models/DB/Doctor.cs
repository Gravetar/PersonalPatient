using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Patient.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string office { get; set; }
        public string specialization { get; set; }
    }
}
