namespace SwaggerSandbox;

/// <summary>
/// Represents a collection response
/// </summary>
/// <param name="Items">The collection returned</param>
/// <typeparam name="T">The type of items in the collection</typeparam>
/// <remarks>
/// <see cref="List{T}" /> cannot be used in <see cref="OpenApiRouteHandlerBuilderExtensions.Produces{TResponse}" />
/// for XML, as the XML response just becomes "XML example cannot be generated; root element name is undefined", so
/// when we use this method to generate XML response examples we have to use this wrapper.
/// </remarks>
public abstract record CollectionResponse<T>(List<T> Items);
