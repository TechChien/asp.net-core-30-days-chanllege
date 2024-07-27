using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);

builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

var app = builder.Build();

if(app.Environment.IsDevelopment()) app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/person", () => new Person("Roger", "Chien"));
app.Run();


public record Person(string FirstName, string LastName);