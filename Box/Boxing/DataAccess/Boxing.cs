using Boxing.DTO;
using Boxing.Entities;
using Boxing.Request;
using Microsoft.EntityFrameworkCore;
using Nutrition.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.DataAccess
{
    public class BoxingClass(HealthServicesContext dbContext)
    {
        public async Task<List<MembersDto>> GetBoxMembers()
        {
            var members = await dbContext.Members.Include(a=>a.Goal).ToListAsync();
            var membertDto = MembersDto.ToMemberDto(members);
            return membertDto;
        }

        public async Task<List<TeachersDto>> GetBoxTeachers()
        {
            var teachers = await dbContext.BoxTeachers.ToListAsync();
            var teacherstDto = TeachersDto.ToBoxTeacherDto(teachers);
            return teacherstDto;
        }
        public async Task<TeachersDto?> GetBoxTeachersById(int id)
        {
            var teachers = await dbContext.BoxTeachers.FirstOrDefaultAsync(a => a.Id == id);
            var teacherstDto = TeachersDto.ToBoxTeacherDto(teachers);
            return teacherstDto;
        }

        public async Task<List<SchedulesDto>> GetSchedules()
        {
            var schedules = await dbContext.BoxSchedules.Include(a => a.Teacher).ToListAsync();
            var schedulestDto = SchedulesDto.ToScheduleDto(schedules);
            return schedulestDto;
        }
        public async Task<SchedulesDto?> GetSchedulesById(int id)
        {
            var schedules = await dbContext.BoxSchedules.Include(a=>a.Teacher).FirstOrDefaultAsync(a => a.Id == id);
            var schedulestDto = SchedulesDto.ToScheduleDto(schedules);
            return schedulestDto;
        }

        public async Task<BoxScheduleMembersDto?> GetMembersBySchedule(int id)
        {
            var scheduleMembers = await dbContext.BoxSchedules.Include(a => a.Members).Include(a=>a.Teacher).FirstOrDefaultAsync(a => a.Id == id);
            var scheduleMembersDto = BoxScheduleMembersDto.ToBoxTeacherMembersDto(scheduleMembers);
            return scheduleMembersDto;
        }

        public async Task<BoxTeacher?> AddBoxTeacher(BoxTeacherRequest boxTeacherRequest)
        {
            BoxTeacher teacher = new BoxTeacher
            {
                FirstName = boxTeacherRequest.FirstName,
                LastName = boxTeacherRequest.LastName,
                Description = boxTeacherRequest.Description,
                Dob = boxTeacherRequest.Dob
            };

            dbContext.BoxTeachers.Add(teacher);
            await dbContext.SaveChangesAsync();

            return teacher;
        }

    }
}
