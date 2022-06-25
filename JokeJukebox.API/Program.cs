using JokeJukebox.Domain.Extensions;
using JokeJukebox.Domain.Mapper;
using JokeJukebox.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(JokeJukeboxProfile));

//Service collection extensions from other assemblies
builder.Services.AddJokeJukeboxDomain(builder.Configuration);
builder.Services.AddJokeJukeboxService();

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
