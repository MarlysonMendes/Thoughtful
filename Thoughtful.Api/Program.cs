using Thoughtful.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
//metodo adicionado Services
builder.Services.addAplicationServices(builder);
builder.RegisterModules();

var app = builder.Build();
app.ConfigureApplication();
app.MapEndpoints();

app.Run();