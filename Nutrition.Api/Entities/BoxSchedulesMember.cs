using System;
using System.Collections.Generic;

namespace Nutrition.Api.Entities;

public partial class BoxSchedulesMember
{
    public int BoxScheduleId { get; set; }

    public int MemberId { get; set; }
}
