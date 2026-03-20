using System;
using System.Collections.Generic;

namespace Gym.Entities;

public partial class Instructor
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Description { get; set; }
}
