using JobOffice.ApplicationServices.API.Domain.Handlers;
using JobOffice.ApplicationServices.Mappings;
using JobOffice.DataAcces;
using JobOffice.DataAcces.CQRS;
using MediatR;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("JobOfficeConnection");
builder.Services.AddDbContext<JobOfficeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobOfficeConnection"));

});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<JobOfficeContext>
//    (opt => opt.UseSqlServer(connectionString: "JobOfficeConnection"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(GetEmployeesHandler));         //Unncomment, while problem.
builder.Services.AddAutoMapper(typeof(EmployeesProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.AllowTrailingCommas = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //options.RoutePrefix = string.Empty;

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
