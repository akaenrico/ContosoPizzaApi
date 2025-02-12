# Following the Microsoft course [Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/)

### Unit 3 of 9
To access HTTP REPL i had to use the following command:

Install httprepl
```pwsh
dotnet tool install -g Microsoft.dotnet-httprepl
```

Connect to the web API
```pwsh
httprepl http://localhost:{PORT}/swagger/v1/swagger.json
```

After accessing for the first time using the command above, i was able to use the suggested command:
```pwsh
httprepl http://localhost:{PORT}
```

**Personal note: Find out why it didn't work out running the suggested command at first**

### Side Quest: Adding Scalar
I was following the instructions present on the [nuget page](https://www.nuget.org/packages/Scalar.AspNetCore) for .NET 8.0 using Swashbuckle and landed on a problem which i think is related to the problem i had before with HTTP REPL. In [Scalar Github](https://github.com/scalar/scalar/blob/main/documentation/integrations/dotnet.md#openapi-document) there's a section called "OpenAPI Document" that states _"If the document is located elsewhere (e.g., when using Swashbuckle or NSwag), specify the path using the OpenApiRoutePattern property"_, well, by default my application came with Swash, the path i have to access to get to my swagger docs is "swagger/v1/swagger.json". So i had to fix this in the Program.cs file.

What was expected to work via nuget is:
```cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/swagger.json";
    });
    app.MapScalarApiReference();
}
```

What ended up working is:
```cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
    });
}
```