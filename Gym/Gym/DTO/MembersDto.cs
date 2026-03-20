using Gym.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DTO
{
    public class MembersDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Goal { get; set; }

        public static List<MembersDto> ToMemberDto(List<Member> entities)
        {
            return entities.Select(p => new MembersDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dob = p.Dob,
                Goal = p.Goal?.Goal1
            }).ToList();
        }

        public static MembersDto? ToMemberDto(Member entity)
        {
            return entity != null ? new MembersDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Dob = entity.Dob,
                Goal = entity.Goal?.Goal1
            } : null;
        }


    }
}
