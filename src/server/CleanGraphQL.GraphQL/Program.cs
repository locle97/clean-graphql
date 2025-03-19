using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using CleanGraphQL.GraphQL;
using CleanGraphQL.GraphQL.Queries;
using CleanGraphQL.Infrastructure.Presistence;
using HotChocolate.Data.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSetting>(
    builder.Configuration.GetSection("MongoDb"));

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
    .AddConvention<IFilterConvention, CustomConvention>()
    .AddFiltering();

var app = builder.Build();

string cors = builder.Configuration.GetValue<string>("CORSOrigins") ?? string.Empty;
string[] corsUrls = cors.Split(';');
app.UseCors(policy => policy.WithOrigins(corsUrls)
                            .AllowAnyHeader()
                            .AllowAnyMethod());

app.MapGet("/", () => "Hello world!");
app.MapGet("/switches", (ISwitchesRepository repo) => repo.GetAll());
app.MapGraphQL();

app.Run();
