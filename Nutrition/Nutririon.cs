using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;

//using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace HealthServices;

public class Nutririon(ILogger<Nutririon> logger, IConfiguration configuration)
{
    private static readonly HttpClient client = new HttpClient();

    [Function("Nutritionists")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        logger.LogInformation("Get Nutritionists request.");
        string result=string.Empty;
        try
        {
            using HttpResponseMessage response = await client.GetAsync(configuration["NutritionAPI"] + "/nutritionists");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            result = responseBody;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(result);
    }

    [Function("NutritionistsById")]
    public IActionResult Run2([HttpTrigger(AuthorizationLevel.Function, "get", Route = "nutritionists/{id}")] HttpRequest req, string id)
    {
        logger.LogInformation("C# HTTP trigger function processed a request. World...");
        return new OkObjectResult("Welcome to Azure Functions!");
    }


}