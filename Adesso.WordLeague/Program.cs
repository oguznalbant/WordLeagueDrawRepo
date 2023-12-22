using Adesso.WordLeague.Data;
using Adesso.WordLeague.Extensions;
using Adesso.WordLeague.Repository;
using Adesso.WordLeague.Repository.Abstracts;
using Adesso.WordLeague.Services;
using Adesso.WordLeague.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDrawService, DrawService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IDrawRepository, DrawRepository>();

builder.Services.AddDbContext<DataContext>
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WLConn")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
