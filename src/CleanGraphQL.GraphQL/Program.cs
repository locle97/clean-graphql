using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using CleanGraphQL.GraphQL;
using CleanGraphQL.Infrastructure.Presistence;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISwitchesRepository, SwitchesRepository>()
                .AddScoped<IBrandsRepository, BrandsRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetSwitchesQuery)));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.Configure<MongoDbSetting>(
    builder.Configuration.GetSection("MongoDb"));

var app = builder.Build();

app.MapGet("/", (ISwitchesRepository switchesRepository) => switchesRepository.GetAll());
app.MapGraphQL();

app.Run();
