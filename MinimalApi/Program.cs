using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using MinimalApi.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();
var app = builder.Build();

app.UseHttpsRedirection();
app.RegisterEndpointDefinitios();

app.Run();