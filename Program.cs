using Microsoft.AspNetCore.Mvc.Controllers;
using SwaggerSandbox;
using SwaggerSandbox.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

AppSettings mySettings = new(false);
builder.Configuration.GetRequiredSection(nameof(AppSettings)).Bind(mySettings);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
  opts.IncludeXmlComments(typeof(WeatherForecast).Assembly, true);
  opts.DocInclusionPredicate((_, description) => 
    // Minimal API endpoints can call ExcludeFromDescription(), so we only care about Controllers here
    description.ActionDescriptor is not ControllerActionDescriptor controllerDescriptor
    // We can rely on configuration to determine whether to show/hide a Controller Action
    || mySettings.ShouldAddToSwagger(controllerDescriptor)
  );
});
builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

string[] summaries =
[
  "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
];

app.MapGet("/weatherforecast", () =>
  {
    List<WeatherForecast> forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
        ))
      .ToList();
    return forecast;
  })
  .WithName("GetWeatherForecast")
  .WithDescription("Returns data for the current weather forecast");
  //.Produces<List<WeatherForecast>>(200, contentType: "application/json", "application/xml");

app.MapGet("/", () => Results.Redirect("/swagger", true, true)).ExcludeFromDescription();

app.Run();
