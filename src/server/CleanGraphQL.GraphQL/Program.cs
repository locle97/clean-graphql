using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using CleanGraphQL.GraphQL.Queries;
using CleanGraphQL.Infrastructure.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISwitchesRepository, SwitchesRepository>()
                .AddScoped<IBrandsRepository, BrandsRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetSwitchesQuery)));

builder.Services.AddCors();

builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddTypeExtension<SwitchesQueries>()
    .AddTypeExtension<BrandsQueries>()
    .AddTypeExtension<SwitchesNode>()
    .AddFiltering();

builder.Services.Configure<MongoDbSetting>(
    builder.Configuration.GetSection("MongoDb"));

var app = builder.Build();

string cors = builder.Configuration.GetValue<string>("CORSOrigins") ?? string.Empty;
string[] corsUrls = cors.Split(';');
app.UseCors(policy => policy.WithOrigins(corsUrls)
                            .AllowAnyHeader()
                            .AllowAnyMethod());

app.MapGraphQL();

app.Run();
