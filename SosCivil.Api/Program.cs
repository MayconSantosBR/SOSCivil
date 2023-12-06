using Amazon.S3;
using DevIO.App.Configurations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using SosCivil.Api.Data.Contexts;
using SosCivil.Api.Models.AutoMapper;
using SosCivil.Api.Repositories;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Requesters;
using SosCivil.Api.Requesters.Interfaces;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

var appConfig = new AppConfig();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(appConfig.GetSetting("ConnectionStrings:SosCivil")));
builder.Services.ResolveDependencies();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICobradeService, CobradeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IRequestItemService, RequestItemService>();
builder.Services.AddScoped<IOccurrenceService, OccurrenceService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IEstablishmentService, EstablishmentService>();
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

builder.Logging.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();