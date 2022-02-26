var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var app = builder.Build();

app.MapGet("/",() => "Hello World");
app.Run(url);