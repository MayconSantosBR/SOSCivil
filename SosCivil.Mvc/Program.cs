using SosCivil.Mvc.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration();

builder.Services.RegisterServices();


var app = builder.Build();

app.UseMvcConfiguration();


await app.RunAsync();