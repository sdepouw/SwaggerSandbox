using Microsoft.AspNetCore.Mvc;
using SwaggerSandbox.Models;

namespace SwaggerSandbox.Controllers;

/// <summary>
/// All about flowers!
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json", "application/xml")]
public class FlowersController : ControllerBase
{
  /// <summary>
  /// Gets a flower
  /// </summary>
  [HttpGet]
  public Flower Get() => new("Rose", "Prickly", "Red", 42);
  
  /// <summary>
  /// Gets a pretty flower
  /// </summary>
  [HttpGet("Pretty")]
  public Flower GetPretty() => new("Daisy", "Soft", "Yellow", 10);
  
  /// <summary>
  /// Gets many flowers
  /// </summary>
  [HttpGet("Many")]
  public List<Flower> GetMany() => [new("A", "T", "R", 5), new("A", "T", "R", 5)];

  /// <summary>
  /// Gets a <see cref="FireFlower" />!
  /// </summary>
  [HttpGet("Fire")]
  public FireFlower GetFireFlower() => new();
}
