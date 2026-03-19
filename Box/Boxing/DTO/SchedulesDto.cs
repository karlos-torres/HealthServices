using Boxing.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grpc.Core.Metadata;

namespace Boxing.DTO
{
    public class SchedulesDto
    {
        public int Id { get; set; }

        public TeachersDto Teacher { get; set; }

        public string DayOfWeek { get; set; }

        public TimeOnly? Starts { get; set; }

        public TimeOnly? Ends { get; set; }

        public static List<SchedulesDto> ToScheduleDto(List<BoxSchedule> entities)
        {
            return entities.Select(p => new SchedulesDto
            {
                Id = p.Id,
                DayOfWeek = Enum.GetName(typeof(DayOfWeek), p.DayOfWeek),
                Starts = p.Starts,
                Ends = p.Ends,
                Teacher = new TeachersDto
                {
                    Id = p.Teacher.Id,
                    FirstName = p.Teacher.FirstName,
                    LastName = p.Teacher.LastName,
                    Description = p.Teacher.Description,
                    Dob = p.Teacher.Dob
                }
            }).ToList();
            
        }

        public static SchedulesDto? ToScheduleDto(BoxSchedule entity)
        {
            return entity != null ? new SchedulesDto
            {
                Id = entity.Id,
                DayOfWeek = Enum.GetName(typeof(DayOfWeek), entity.DayOfWeek),
                Starts = entity.Starts,
                Ends = entity.Ends,
                Teacher = new TeachersDto
                {
                    Id = entity.Teacher.Id,
                    FirstName = entity.Teacher.FirstName,
                    LastName= entity.Teacher.LastName,
                    Description = entity.Teacher.Description,
                    Dob= entity.Teacher.Dob
                }
            } : null;
        }




    }
}
