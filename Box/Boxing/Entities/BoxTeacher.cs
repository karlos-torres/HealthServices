using System;
using System.Collections.Generic;

namespace Boxing.Entities;

public partial class BoxTeacher
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BoxSchedule> BoxSchedules { get; set; } = new List<BoxSchedule>();
}
