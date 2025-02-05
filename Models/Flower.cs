namespace SwaggerSandbox.Models;

/// <summary>
/// Represents a flower
/// </summary>
/// <param name="Name">The name of the flower</param>
/// <param name="Type">The flower's type</param>
/// <param name="Color">The flower's primary color</param>
/// <param name="PetalsCount">The average number of petals the flower has</param>
public record Flower(string Name, string Type, string Color, int PetalsCount);
