using pizza.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPizzasEndpoints();

app.Run();
