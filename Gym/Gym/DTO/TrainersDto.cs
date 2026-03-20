using Gym.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DTO
{
    public class TrainersDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Description { get; set; }

        public static List<TrainersDto> ToTrainerDto(List<Instructor> entities)
        {
            return entities.Select(p => new TrainersDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dob = p.Dob,
                Description = p.Description
            }).ToList();
        }

        public static TrainersDto? ToTrainerDto(Instructor entity)
        {
            return entity != null ? new TrainersDto
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
