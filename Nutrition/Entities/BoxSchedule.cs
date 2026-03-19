using System;
using System.Collections.Generic;

namespace Nutrition.Entities;

public partial class BoxSchedule
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? DayOfWeek { get; set; }

    public TimeOnly? Starts { get; set; }

    public TimeOnly? Ends { get; set; }
}
