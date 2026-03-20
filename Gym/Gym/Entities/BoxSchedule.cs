using System;
using System.Collections.Generic;

namespace Gym.Entities;

public partial class BoxSchedule
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? DayOfWeek { get; set; }

    public TimeOnly? Starts { get; set; }

    public TimeOnly? Ends { get; set; }

    public virtual BoxTeacher? Teacher { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
