using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using ViagemProjeto.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello, Minimal API!");

app.Run();