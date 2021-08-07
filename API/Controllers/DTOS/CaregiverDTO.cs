using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DTOS
{
    public class CaregiverDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public DateTime birthDate { get; set; }

        public string password { get; set; }

        public string gender { get; set; }

        public string address { get; set; }

        public List<PatientDTO> patients { get; set; }
    }
}
