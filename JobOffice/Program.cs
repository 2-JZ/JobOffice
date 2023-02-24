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
using Microsoft.AspNetCore.Mvc;
[assembly: ApiController]


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();


string connectionString = builder.Configuration.GetConnectionString("JobOfficeConnection");
builder.Services.AddDbContext<JobOfficeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobOfficeConnection"));

});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(typeof(GetEmployeesHandler));
builder.Services.AddAutoMapper(typeof(EmployeesProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<ICurrencyNbpConnector, CurrencyNbpConnector>();
builder.Services.AddTransient<IHashingPassword, HashingPassword>();
builder.Services.AddMvcCore()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddContractorRequest>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAuthentication("BasicAuthentication").
                AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddRazorPages();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
//builder.Services.AddAuthentication("BasicAuthentication").
//                AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;
        //app.UseMiddleware<BasicAuthenticationHandler>(); //Last thing that i'd added


    });
}
//app.UseMiddleware<BasicAuthenticationHandler>(); //Last thing that i'd added


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseAuthentication();


app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
