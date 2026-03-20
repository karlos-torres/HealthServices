using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Request
{
    public class MemberRequest
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? Dob { get; set; }

        public int? GoalId { get; set; }
    }
}
