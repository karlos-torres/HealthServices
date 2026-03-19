using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DTO
{
    public class PatientsDto
    {
        public int PatientId { get; set; }

        public string? PatientFirstName { get; set; }

        public string? PatientLastName { get; set; }

        public DateOnly? PatientDob { get; set; }

        public string? PatientDescription { get; set; }
    }
}
