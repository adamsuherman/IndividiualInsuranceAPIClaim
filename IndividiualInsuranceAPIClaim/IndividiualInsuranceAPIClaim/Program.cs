using IndividiualInsuranceAPIClaim.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var MembershipConnectionString = builder.Configuration.GetConnectionString("MembershipConnection");

// Add services to the container.
builder.Services.AddDbContext<ClaimContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<MembershipContext>(options => options.UseSqlServer(MembershipConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
