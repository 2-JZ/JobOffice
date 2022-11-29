using JobOffice.ApplicationServices.API.Domain.Handlers;
using JobOffice.DataAcces;
using MediatR;
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
