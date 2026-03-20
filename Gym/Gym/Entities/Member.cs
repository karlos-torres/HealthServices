using System;
using System.Collections.Generic;

namespace Gym.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public int? GoalId { get; set; }

    public virtual Goal? Goal { get; set; }

    public virtual ICollection<BoxSchedule> BoxSchedules { get; set; } = new List<BoxSchedule>();

    public virtual ICollection<Nutritionist> Nutritionists { get; set; } = new List<Nutritionist>();
}
