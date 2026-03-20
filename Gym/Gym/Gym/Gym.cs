using Gym.DataAccess;
using Gym.DTO;
using Gym.Entities;
using Gym.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Gym.Gym;

public class Gym(ILogger<Gym> logger, HealthServicesContext dbContext)
{
    private GymClass gym = new GymClass(dbContext);

    [Function("GymMembers")]
    public async Task<IActionResult> GetMembers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "members")] HttpRequest req)
    {
        List<MembersDto>? memberDto = null;

        try
        {
            memberDto = await gym.GetGymMembers();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(memberDto);

    }

    [Function("GymMembersById")]
    public async Task<IActionResult> GetGymMemberById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "members/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Member by Id request.");
        MembersDto? responseDto = null;

        try
        {
            responseDto = await gym.GetGymMembersById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }

    [Function("GymTrainers")]
    public async Task<IActionResult> GetTrainers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "trainers")] HttpRequest req)
    {
        List<TrainersDto>? trainerDto = null;

        try
        {
            trainerDto = await gym.GetTrainers();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(trainerDto);
    }

    [Function("GymTrainersById")]
    public async Task<IActionResult> GetTrainersById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "trainers/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Trainer by Id request.");
        TrainersDto? responseDto = null;

        try
        {
            responseDto = await gym.GetTrainersById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }

    [Function("RoutineById")]
    public async Task<IActionResult> GetRoutineById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "routines/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Routine by Id request.");
        RoutinesDto? responseDto = null;

        try
        {
            responseDto = await gym.GetRoutineById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }

    [Function("Goals")]
    public async Task<IActionResult> GetGoals([HttpTrigger(AuthorizationLevel.Function, "get", Route = "goals")] HttpRequest req)
    {
        List<GoalsDto>? goalDto = null;

        try
        {
            goalDto = await gym.GetGoals();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(goalDto);
    }

    [Function("AddMembers")]
    public async Task<IActionResult> AddMembers([HttpTrigger(AuthorizationLevel.Function, "post", Route = "members")] HttpRequest req)
    {
        MemberRequest? memberRequest = null;
        Member? response = null;

        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            memberRequest = JsonSerializer.Deserialize<MemberRequest>(requestBody, options);

            response = await gym.AddMember(memberRequest);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(response);
    }

}