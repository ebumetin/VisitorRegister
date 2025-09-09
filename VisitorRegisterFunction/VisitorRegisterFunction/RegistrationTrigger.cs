using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace VisitorRegisterFunction;

public class RegistrationTrigger
{
    private readonly ILogger<RegistrationTrigger> _logger;

    public RegistrationTrigger(ILogger<RegistrationTrigger> logger)
    {
        _logger = logger;
    }

    [Function("RegistrationTrigger")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var name = await new StreamReader(req.Body).ReadToEndAsync();
        _logger.LogInformation("New visitor registration request: {Name}", name);

        try
        {
            var client =
                new CosmosClient(
                    Environment.GetEnvironmentVariable("CosmosConnectionString"));
            var container = client.GetContainer("visitor-register-db", "visitors");
        
            await container.CreateItemAsync(new
            {
                id = Guid.NewGuid().ToString(),
                Name = name,
                CreatedAt = DateTime.UtcNow
            });
            _logger.LogInformation("User {Name} registered successfully", name);
            return new OkObjectResult($"User {name} registered successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occured while processing request: {Name}", name);
            return new StatusCodeResult(500);
        }
    }
}