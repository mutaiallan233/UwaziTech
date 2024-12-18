using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using UwaziTech.Core.Services;
using UwaziTech.Core.Services.Interfaces;
using UwaziTech.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();

//register services & lifetime
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IHospitalService, HospitalService>();
builder.Services.AddTransient<IInsuranceService, InsuranceService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);


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
