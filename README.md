# Following the Microsoft course [Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/)

Unit 3 of 9
To access HTTP REPL i had to use the following command:

Install httprepl
```pwsh
dotnet tool install -g Microsoft.dotnet-httprepl
```

Connect to the web API
```pwsh
httprepl http://localhost:{PORT}/swagger/v1/swagger.json
```
