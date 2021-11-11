
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseMySql(connectionString,
                            ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<ILugarRepository, LugarRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Applying the migrations and creating the Database at app 
using (var scope = app.Services.CreateScope())
{
     var services = scope.ServiceProvider;
     var loggerFactory = services.GetRequiredService<ILoggerFactory>();
     try
     {
          var context = services.GetRequiredService<ApplicationDbContext>();
          await context.Database.MigrateAsync();
          await StoreContextSeed.SeedAsync(context, loggerFactory);
     }
     catch (System.Exception ex)
     {
         var logger = loggerFactory.CreateLogger<Program>();
         logger.LogError(ex, "An Error occured during migration");
     }
}

// End

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
