

using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using SignalAppTrial.Application.Abstract;
using SignalAppTrial.Application.BackgroundJobs.Schedules;
using SignalAppTrial.Application.Concrete;
using SignalAppTrial.DataAccess.Abstract;
using SignalAppTrial.DataAccess.Concrete;
using SignalAppTrial.DataAccess.Contexts;
using SignalAppTrial.Model.Options;
using SignalAppTrial.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
.WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
.MinimumLevel.Information()
.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning) // namespace specific log
.MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // ef core query log disabled
.Enrich.FromLogContext()
.CreateLogger();

builder
    .Host
        .ConfigureLogging(config => config.ClearProviders())
        .UseSerilog();

builder.Services.AddDbContext<Context>();
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

var _connectionStrings = new ConnectionStrings();
config.Bind(nameof(ConnectionStrings), _connectionStrings);

var _appConfig = new AppConfig();
config.Bind(nameof(AppConfig), _appConfig);


builder.Services.AddCors(c =>
{
    c.AddPolicy(_appConfig.CorsOriginPolicyName, options => options
        .WithOrigins(_appConfig.CorsOrigins.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray())
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});



builder.Services.AddSingleton<ConnectionStrings>(_connectionStrings);
builder.Services.AddSingleton<AppConfig>(_appConfig);
builder.Services.AddTransient<DbContext, Context>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<ISignalRepository, SignalRepository>();
builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<ICoinGeckoService, CoinGeckoService>();

builder.Services.AddHangfire(x =>
        x.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));
builder.Services.AddHangfireServer();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(_appConfig.CorsOriginPolicyName);
JobStorage.Current = new SqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    ReccuringJobs.GetAll(_appConfig);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard();
app.UseAuthorization();
app.UseWebSockets();
app.MapControllers();

app.Run();
