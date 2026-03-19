using Microsoft.EntityFrameworkCore;
using Nutrition.DTO;
using Nutrition.Entities;
using Nutrition.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DataAccess
{
    public class Nutritionists(HealthServicesContext dbContext)
    {
        public async Task<List<NutritionistDto>> GetNutritionists()
        {
            var nutritionists = await dbContext.Nutritionists.ToListAsync();
            var nutrionistDto = NutritionistDto.ToNutritionistDto(nutritionists);
            return nutrionistDto;
        }

        public async Task<NutritionistDto?> GetNutritionistById(int id)
        {
            var nutritionist = await dbContext.Nutritionists.FirstOrDefaultAsync(a=>a.Id ==id);
            var nutrionistDto = NutritionistDto.ToNutritionistDto(nutritionist);
            return nutrionistDto;
        }

        public async Task<NutritionistPatientsDto?> GetPatientsByNutritionist(int id)
        {
            var nutritionistPatients = await dbContext.Nutritionists.Include(a => a.Patients).FirstOrDefaultAsync(a => a.Id == id);
            var nutrionistPatientsDto = NutritionistPatientsDto.ToNutritionistPatientsDto(nutritionistPatients);
            return nutrionistPatientsDto;
        }
        public async Task<Nutritionist?> AddNutritionist(NutritionistRequest nutritionistRequest)
        {
            Nutritionist patient = new Nutritionist
            {
                FirstName = nutritionistRequest.FirstName,
                LastName = nutritionistRequest.LastName,
                Description = nutritionistRequest.Description,
                Dob = nutritionistRequest.Dob
            };

            dbContext.Nutritionists.Add(patient);
            await dbContext.SaveChangesAsync();

            return patient;
        }

    }
}
