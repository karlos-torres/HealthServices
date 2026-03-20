using Gym.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DTO
{
    public class GoalsDto
    {
        public int Id { get; set; }

        public string? Goal { get; set; }


        public static List<GoalsDto> ToGoalDto(List<Goal> entities)
        {
            return entities.Select(p => new GoalsDto
            {
                Id = p.Id,
                Goal = p.Goal1
            }).ToList();
        }

        public static GoalsDto? ToGoalDto(Goal entity)
        {
            return entity != null ? new GoalsDto
            {
                Id = entity.Id,
                Goal = entity.Goal1
            } : null;
        }
    }

}

