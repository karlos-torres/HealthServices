using System;
using System.Collections.Generic;

namespace Nutrition.Api.Entities;

public partial class NutritionistsPatient
{
    public int NutritionistId { get; set; }

    public int PatientId { get; set; }
}
