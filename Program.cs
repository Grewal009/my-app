using pizza.api.Endpoints;
using pizza.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPizzasRepository, InMemoryPizzasRepository>();

var connString = builder.Configuration.GetConnectionString("PizzaContext");

var app = builder.Build();

app.MapPizzasEndpoints();

app.Run();
