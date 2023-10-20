using EngiePowePlantBL.Interfaces;
using EngiePowePlantBL.Services;
using EngiePowerPlantAPI;
using EngiePowerPlantAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(); // configure json services for JSON formatting.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPowerPlantService, PowerPlantService>();
builder.Services.AddAutoMapper(typeof(MapperClass));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Error handling.
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
