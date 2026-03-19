using Boxing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.DTO
{
    public class TeachersDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Description { get; set; }

        public static List<TeachersDto> ToBoxTeacherDto(List<BoxTeacher> entities)
        {
            return entities.Select(p => new TeachersDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dob = p.Dob,
                Description = p.Description
            }).ToList();
        }

        public static TeachersDto? ToBoxTeacherDto(BoxTeacher entity)
        {
            return entity != null ? new TeachersDto
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
