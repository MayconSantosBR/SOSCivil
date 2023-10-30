using DevIO.App.Configurations;
using Microsoft.EntityFrameworkCore;
using SosCivil.Api.Data.Contexts;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.AutoMapper;
using SosCivil.Api.Repositories;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Requesters;
using SosCivil.Api.Requesters.Interfaces;
using SosCivil.Api.Services;

var appConfig = new AppConfig();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(appConfig.GetSetting("ConnectionStrings:SosCivil")));
builder.Services.ResolveDependencies();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICobradeService, CobradeService>();
builder.Services.AddScoped<IS2idRequester, S2idRequester>();

builder.Services.AddHttpClient<IS2idRequester, S2idRequester>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        return handler;
    })
    .ConfigureHttpClient((serviceProvider, httpClient) =>
    {
        var appConfig = serviceProvider.GetRequiredService<IConfiguration>();

        httpClient.BaseAddress = new Uri(appConfig.GetValue<string>("S2id:Url"));
    });


builder.Services.AddAutoMapper(typeof(Mapper));

//Add logger console
builder.Logging.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();