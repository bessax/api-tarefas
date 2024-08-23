namespace api.tarefas.Modelos;

public class Tarefa
{
    public Tarefa()
    {
        Id = Guid.NewGuid();
        DataInicio = DateTime.Now;
        Status = Status.Iniciado;
    }
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Iniciado,
    EmAndamento,
    Concluido,
    Cancelado
}