using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
         public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                 if(!context.Pais.Any())
                 {
                     var paisesData = File.ReadAllText("../Infrastructure/Data/SeedData/paises.json");
                     var paises = JsonSerializer.Deserialize<List<Pais>>(paisesData);

                     foreach (var item in paises)
                     {
                         await context.Pais.AddAsync(item);
                     }
                     await context.SaveChangesAsync();
                 }

                 if(!context.Categoria.Any())
                 {
                     var categoriasData = File.ReadAllText("../Infrastructure/Data/SeedData/categorias.json");
                     var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                     foreach (var item in categorias)
                     {
                         await context.Categoria.AddAsync(item);
                     }
                     await context.SaveChangesAsync();
                 }

                 if(!context.Lugar.Any())
                 {
                     var lugaresData = File.ReadAllText("../Infrastructure/Data/SeedData/lugares.json");
                     var lugares = JsonSerializer.Deserialize<List<Lugar>>(lugaresData);

                     foreach (var item in lugares)
                     {
                         await context.Lugar.AddAsync(item);
                     }
                     await context.SaveChangesAsync();
                 }

            }
            catch (System.Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}