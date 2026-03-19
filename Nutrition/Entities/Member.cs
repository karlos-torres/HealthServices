using System;
using System.Collections.Generic;

namespace Nutrition.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public int? GoalId { get; set; }

    public virtual ICollection<Nutritionist> Nutritionists { get; set; } = new List<Nutritionist>();
}
