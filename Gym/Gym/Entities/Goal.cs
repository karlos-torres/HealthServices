using System;
using System.Collections.Generic;

namespace Gym.Entities;

public partial class Goal
{
    public int Id { get; set; }

    public string? Goal1 { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
