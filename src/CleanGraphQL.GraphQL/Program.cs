using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using CleanGraphQL.GraphQL;
using CleanGraphQL.Infrastructure.Presistence;

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

app.MapGraphQL();

app.Run();
