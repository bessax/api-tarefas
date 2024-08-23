using api.tarefas.Modelos;
using System.ComponentModel.DataAnnotations;

namespace api.tarefas.DTO;

public class TarefaDTO
{
    public Guid Id { get; set; }
    [Required]
    [MinLength(3)]
    public string? Nome { get; set; }
    [Required]
    [MinLength(5)]  
    public string? Descricao { get; set; }
}
