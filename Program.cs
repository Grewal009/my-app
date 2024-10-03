using Microsoft.EntityFrameworkCore;
using pizza.api.Data;
using pizza.api.Endpoints;
using pizza.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPizzasRepository, InMemoryPizzasRepository>();

var connString = builder.Configuration.GetConnectionString("PizzaContext");

builder.Services.AddSqlServer<PizzaContext>(connString);

var app = builder.Build();

//apply migrations on application startup
app.Services.InitializeDb();

app.MapPizzasEndpoints();

app.Run();
