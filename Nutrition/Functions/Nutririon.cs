using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;

//using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Nutrition.DataAccess;
using Nutrition.DTO;
using Nutrition.Entities;
using Nutrition.Request;
using System.Text.Json;

namespace Nutrition.Functions;

public class Nutririon(ILogger<Nutririon> logger, IConfiguration configuration, HealthServicesContext dbContext)
{
    private Nutritionists nutrition = new Nutritionists(dbContext);

    [Function("Nutritionists")]
    public async Task<IActionResult> GetNutritionists([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        List<NutritionistDto>? responseDto = null;

        try
        {
            responseDto = await nutrition.GetNutritionists();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(responseDto);
    }

    [Function("AddNutritionists")]
    public async Task<IActionResult> AddNutritionists([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        NutritionistRequest? nutritionistRequest = null;
        Nutritionist? response =null;

        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            nutritionistRequest = JsonSerializer.Deserialize<NutritionistRequest>(requestBody, options);

            response = await nutrition.AddNutritionist(nutritionistRequest);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(response);
    }

    [Function("NutritionistsById")]
    public async Task<IActionResult> GetNutritionistsById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "nutritionists/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Nutritionist by Id request.");
        NutritionistDto? responseDto = null;

        try
        {
            responseDto = await nutrition.GetNutritionistById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return  responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }


    [Function("PatientsByNutritionist")]
    public async Task<IActionResult> GetPatientsByNutritionist([HttpTrigger(AuthorizationLevel.Function, "get", Route = "nutritionists/{id}/patients")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Patients by nutririonist request.");
        NutritionistPatientsDto? responseDto = null;

        try
        {
            responseDto = await nutrition.GetPatientsByNutritionist(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }

}