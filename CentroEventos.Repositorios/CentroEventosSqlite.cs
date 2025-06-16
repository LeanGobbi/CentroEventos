using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creo la base de datos correctamente");
        }
        
        var connection = context.Database.GetDbConnection(); 
        connection.Open(); 
        using (var command = connection.CreateCommand()) 
        { 
            command.CommandText = "PRAGMA journal_mode=DELETE;"; 
            command.ExecuteNonQuery(); 
        } 
    }
}