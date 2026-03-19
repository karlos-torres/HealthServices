using Nutrition.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DTO
{
    public partial class NutritionistDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Description { get; set; }


        public static List<NutritionistDto> ToNutritionistDto(List<Nutritionist> entities)
        {
            return entities.Select(p => new NutritionistDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dob = p.Dob,
                Description = p.Description
            }).ToList();
        }

        public static NutritionistDto? ToNutritionistDto(Nutritionist entity)
        {
            return entity != null ? new NutritionistDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Dob = entity.Dob,
                Description = entity.Description
            } : null;
        }
    }

}
