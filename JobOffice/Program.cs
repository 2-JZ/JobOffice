using FluentValidation.AspNetCore;
using JobOffice.ApplicationServices.API.Domain;
using JobOffice.ApplicationServices.API.Domain.Handlers;
using JobOffice.ApplicationServices.Components.HashingPassword;
using JobOffice.ApplicationServices.Components.NBPWeb;
using JobOffice.ApplicationServices.Mappings;
using JobOffice.Authentication;
using JobOffice.DataAcces;
using JobOffice.DataAcces.CQRS;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using JobOffice.ApplicationServices.API.Domain.Models;
using JobOffice.ApplicationServices.Components.ContactForm;
using Microsoft.Extensions.Configuration;
using Stripe;

[assembly: ApiController]

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>(); // <-- Add this line to include user secrets


// Configure logging
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Configure database context
string connectionString = builder.Configuration.GetConnectionString("JobOfficeConnection");
builder.Services.AddDbContext<JobOfficeContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("JobOffice.DataAcces"));
});

// Add services to the container
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register dependencies
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(typeof(GetEmployeesHandler));
builder.Services.AddAutoMapper(typeof(EmployeesProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<ICurrencyNbpConnector, CurrencyNbpConnector>();
builder.Services.AddTransient<IHashingPassword, HashingPassword>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

// Retrieve Stripe API key from environment variables or user secrets
//var stripeApiKey = builder.Configuration["Stripe:ApiKey"]; // <-- Access the Stripe key here

//if (string.IsNullOrEmpty(stripeApiKey))
//{
//    throw new InvalidOperationException("Stripe API key is not set in environment variables, user secrets, or appsettings.json.");
//}

//// Add Stripe service to the container
//builder.Services.AddScoped<IStripeService, StripeService>(provider =>
//    new StripeService(stripeApiKey));

builder.Services.AddScoped<IStripeService, StripeService>();


builder.Services.AddMvcCore()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCategoryRequest>());

// Configure API behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Configure authentication
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

// Add Razor Pages (if needed, usually for Blazor)
builder.Services.AddRazorPages();

// Build application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

// Enable serving static files
app.UseStaticFiles(); // This allows serving files from wwwroot

app.UseHttpsRedirection();
app.UseRouting();

// Configure CORS
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapRazorPages();
app.MapControllers();

// Run the application
app.Run();
