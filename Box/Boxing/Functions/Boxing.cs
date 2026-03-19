using Boxing.DataAccess;
using Boxing.DTO;
using Boxing.Entities;
using Boxing.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Nutrition.DTO;
using System.Text.Json;

namespace Boxing.Functions;

public class Boxing(ILogger<Boxing> logger, HealthServicesContext dbContext)
{
    private BoxingClass boxing = new BoxingClass(dbContext);

    [Function("Members")]
    public async Task<IActionResult> GetMembers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "members")] HttpRequest req)
    {
        List<MembersDto>? memberDto = null;

        try
        {
            memberDto = await boxing.GetBoxMembers();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(memberDto);

    }


    [Function("BoxTeachers")]
    public async Task<IActionResult> GetBoxTeachers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "teachers")] HttpRequest req)
    {
        List<TeachersDto>? teachersDto = null;

        try
        {
            teachersDto = await boxing.GetBoxTeachers();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(teachersDto);

    }



    [Function("AddBoxTeachers")]
    public async Task<IActionResult> AddBoxTeachers([HttpTrigger(AuthorizationLevel.Function, "post", Route = "nutritionists")] HttpRequest req)
    {
        BoxTeacherRequest? boxTeacherRequest = null;
        BoxTeacher? response = null;

        try
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            boxTeacherRequest = JsonSerializer.Deserialize<BoxTeacherRequest>(requestBody, options);

            response = await boxing.AddBoxTeacher(boxTeacherRequest);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(response);
    }

    [Function("BoxTeacherById")]
    public async Task<IActionResult> GetBoxTeacherId([HttpTrigger(AuthorizationLevel.Function, "get", Route = "teachers/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get Teacher by Id request.");
        TeachersDto? responseDto = null;

        try
        {
            responseDto = await boxing.GetBoxTeachersById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }


    [Function("Schedules")]
    public async Task<IActionResult> GetSchedules([HttpTrigger(AuthorizationLevel.Function, "get", Route = "schedules")] HttpRequest req)
    {
        List<SchedulesDto>? schedulessDto = null;

        try
        {
            schedulessDto = await boxing.GetSchedules();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return new OkObjectResult(schedulessDto);
    }


    [Function("SchedulesById")]
    public async Task<IActionResult> GetScheduleById([HttpTrigger(AuthorizationLevel.Function, "get", Route = "schedules/{id}")] HttpRequest req, int id)
    {
        logger.LogInformation("Get schedule by Id request.");
        SchedulesDto? responseDto = null;

        try
        {
            responseDto = await boxing.GetSchedulesById(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }



    [Function("MembersBySchedule")]
    public async Task<IActionResult> GetMembersBySchedulet([HttpTrigger(AuthorizationLevel.Function, "get", Route = "schedules/{id}/members")] HttpRequest req, int id)
    {
        logger.LogInformation("Get members by schedule request.");
        BoxScheduleMembersDto? responseDto = null;

        try
        {
            responseDto = await boxing.GetMembersBySchedule(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        return responseDto != null ? new OkObjectResult(responseDto) : new NotFoundResult();
    }





}