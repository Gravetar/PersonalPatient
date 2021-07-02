using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Patient.Models
{
    public class Patient
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string password { get; set; }
        public DateTime dateofbirth { get; set; }
        public string numberpolicy { get; set; }
        public string numberpassport { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string photourl { get; set; }
    }
}
