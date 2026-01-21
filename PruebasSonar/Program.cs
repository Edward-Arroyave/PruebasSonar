var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IGreetingService, GreetingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var greetingGroup = app.MapGroup("/api/greeting").WithName("Greeting").WithOpenApi();

greetingGroup.MapGet("/hello", GetGreeting)
    .WithName("GetGreeting")
    .WithOpenApi()
    .Produces<GreetingResponse>(StatusCodes.Status200OK);

app.Run();

static IResult GetGreeting(IGreetingService service)
{
    var message = service.GetGreetingMessage();
    return Results.Ok(new GreetingResponse { Message = message });
}

public interface IGreetingService
{
    string GetGreetingMessage();
}

public class GreetingService : IGreetingService
{
    public string GetGreetingMessage()
    {
        return "Hola desde PruebasSonar API";
    }
}

public class GreetingResponse
{
    public string Message { get; set; } = string.Empty;
}
