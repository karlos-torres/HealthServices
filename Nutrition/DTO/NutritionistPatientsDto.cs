using Nutrition.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DTO
{
    public class NutritionistPatientsDto
    {
        public int NutritionistId { get; set; }

        public string? NutritionistFirstName { get; set; }

        public string? NutritionistLastName { get; set; }

        public DateOnly? NutritionistDob { get; set; }

        public string? NutritionistDescription { get; set; }

        public List<PatientsDto>? Patients { get; set; }

        public static NutritionistPatientsDto? ToNutritionistPatientsDto(Nutritionist entity)
        {
            return entity != null ? new NutritionistPatientsDto
            {
                NutritionistId = entity.Id,
                NutritionistFirstName = entity.FirstName,
                NutritionistLastName = entity.LastName,
                NutritionistDob = entity.Dob,
                NutritionistDescription = entity.Description,
                Patients = entity.Patients.Select(p => new PatientsDto { 
                    PatientId = p.Id, 
                    PatientFirstName = p.FirstName,
                   PatientLastName = p.LastName,
                    PatientDob = p.Dob,
                }).ToList()
            } : null;
        }
    }
}
