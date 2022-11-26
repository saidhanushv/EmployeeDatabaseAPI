using EmployeeDatabase.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//creating InMemory Database
//builder.Services.AddDbContext<EmployeeDatabaseDbContext>(options => options.UseInMemoryDatabase("EmployeesDb"));

//Using employee database in SQLServer
builder.Services.AddDbContext<EmployeeDatabaseDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDatabaseConnectionString")));

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
