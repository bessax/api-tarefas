using api.tarefas.Modelos;
using Microsoft.EntityFrameworkCore;

namespace api.tarefas;

public class TarefaContext:DbContext
{
    public TarefaContext()
    {
        
    }

    public DbSet<Tarefa> Tarefas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TarefasBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString);

        optionsBuilder.LogTo(Console.WriteLine);

    }


}
