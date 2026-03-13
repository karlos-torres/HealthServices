using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutrition.Api.DataAccess;

namespace Nutrition.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NutritionController(ILogger<NutritionController> logger, HealthServicesContext dbContext) : ControllerBase
{

    [HttpGet("Nutritionists")]
    public async Task<IActionResult> Get()
    {
        var nutritionists = await dbContext.Nutritionists.ToListAsync();

        return Ok(nutritionists);

    }
}
