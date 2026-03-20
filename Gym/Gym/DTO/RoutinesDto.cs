using Gym.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DTO
{
    public class RoutinesDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public static List<RoutinesDto> ToRoutineDto(List<Routine> entities)
        {
            return entities.Select(p => new RoutinesDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            }).ToList();
        }

        public static RoutinesDto? ToRoutineDto(Routine entity)
        {
            return entity != null ? new RoutinesDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description
            } : null;
        }
    }
}
