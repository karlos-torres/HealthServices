using Boxing.DTO;
using Boxing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.DTO
{
    public class BoxScheduleMembersDto
    {
        public int Id { get; set; }

        public string DayOfWeek { get; set; }
        public TimeOnly? Starts { get; set; }

        public TimeOnly? Ends { get; set; }

        public TeachersDto Teacher { get; set; }

        public List<MembersDto>? Members { get; set; }

        public static BoxScheduleMembersDto? ToBoxTeacherMembersDto(BoxSchedule entity)
        {
            return entity != null ? new BoxScheduleMembersDto
            {
                Id = entity.Id,
                DayOfWeek = Enum.GetName(typeof(DayOfWeek), entity.DayOfWeek),
                Starts = entity.Starts,
                Ends = entity.Ends,
                Teacher = new TeachersDto
                {
                    Id = entity.Teacher.Id,
                    FirstName = entity.Teacher.FirstName,
                    LastName = entity.Teacher.LastName,
                    Dob = entity.Teacher.Dob,
                    Description = entity.Teacher.Description,
                },
                Members = [.. entity.Members.Select(p=> new MembersDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Dob = p.Dob,
                })]
            } : null;
        }
    }
}
