namespace SwaggerSandbox;

/// <summary>
/// Describes a weather forecast
/// </summary>
/// <param name="Date">The date the forecast applies to</param>
/// <param name="TemperatureC">The temperature expressed in degrees Celsius</param>
/// <param name="Summary">A summary of the forecast</param>
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
  /// <summary>
  /// The temperature expressed in degrees Fahrenheit
  /// </summary>
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
