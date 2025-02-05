using Microsoft.AspNetCore.Mvc.Controllers;
using SwaggerSandbox.Controllers;

namespace SwaggerSandbox;

/// <summary>
/// Application settings
/// </summary>
/// <param name="AllowPowerUps">Whether power-ups are permitted</param>
public record AppSettings(bool AllowPowerUps)
{
  /// <summary>
  /// Determines whether to add the given Controller/Action
  /// to the generated Swagger documentation
  /// </summary>
  public bool ShouldAddToSwagger(ControllerActionDescriptor descriptor)
  {
    bool isFireFlowerAction = descriptor is { ControllerTypeInfo.Name: nameof(FlowersController),
      ActionName: nameof(FlowersController.GetFireFlower) };
    return !isFireFlowerAction || AllowPowerUps;
  }
}
