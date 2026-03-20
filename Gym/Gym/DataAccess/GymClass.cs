using Gym.DTO;
using Gym.Entities;
using Gym.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DataAccess
{
    public class GymClass(HealthServicesContext dbContext)
    {
        public async Task<List<MembersDto>> GetGymMembers()
        {
            var members = await dbContext.Members.Include(a => a.Goal).ToListAsync();
            var membertDto = MembersDto.ToMemberDto(members);
            return membertDto;
        }

        public async Task<MembersDto?> GetGymMembersById(int id)
        {
            var members = await dbContext.Members.Include(g=>g.Goal).FirstOrDefaultAsync(a => a.Id == id);
            var teacherstDto = MembersDto.ToMemberDto(members);
            return teacherstDto;
        }

        public async Task<List<TrainersDto>> GetTrainers()
        {
            var trainers = await dbContext.Instructors.ToListAsync();
            var trainertDto = TrainersDto.ToTrainerDto(trainers);
            return trainertDto;
        }

        public async Task<TrainersDto?> GetTrainersById(int id)
        {
            var trainers = await dbContext.Instructors.FirstOrDefaultAsync(a => a.Id == id);
            var trainerstDto = TrainersDto.ToTrainerDto(trainers);
            return trainerstDto;
        }

        public async Task<RoutinesDto?> GetRoutineById(int id)
        {
            var routine = await dbContext.Routines.FirstOrDefaultAsync(a => a.Id == id);
            var routineDto = RoutinesDto.ToRoutineDto(routine);
            return routineDto;
        }

        public async Task<List<GoalsDto>> GetGoals()
        {
            var goals = await dbContext.Goals.ToListAsync();
            var goalsDto = GoalsDto.ToGoalDto(goals);
            return goalsDto;
        }

        public async Task<Member?> AddMember(MemberRequest memberRequest)
        {
            Member member = new Member
            {
                FirstName = memberRequest.FirstName,
                LastName = memberRequest.LastName,
                GoalId = memberRequest.GoalId,
                Dob = memberRequest.Dob
            };

            dbContext.Members.Add(member);
            await dbContext.SaveChangesAsync();

            return member;
        }

    }
}
