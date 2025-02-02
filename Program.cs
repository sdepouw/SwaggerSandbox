using SwaggerSandbox;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => opts.IncludeXmlComments(typeof(WeatherForecast).Assembly));

WebApplication app = builder.Build();

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
  .WithDescription("Returns data for the current weather forecast")
  .Produces<CollectionResponse<WeatherForecast>>(200, contentType: "application/json", "application/xml");


app.MapGet("/", () => Results.Redirect("/swagger", true, true)).ExcludeFromDescription();

app.Run();
