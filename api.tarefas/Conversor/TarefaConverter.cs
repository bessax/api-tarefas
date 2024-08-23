using api.tarefas.DTO;
using api.tarefas.Modelos;

namespace api.tarefas.Conversor;

public class TarefaConverter
{
    public Tarefa DtoToEntity(TarefaDTO dto)
    {
        return new Tarefa
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };
    }

    public TarefaDTO EntityToDto(Tarefa tarefa)
    {
        return new TarefaDTO
        {
            Id = tarefa.Id,
            Nome = tarefa.Nome,
            Descricao = tarefa.Descricao
        };
    }

    public IEnumerable<TarefaDTO> EntityListToDtoList(IEnumerable<Tarefa> tarefas)
    {
        return tarefas.Select(tarefa => new TarefaDTO
        {
            Id = tarefa.Id,
            Nome = tarefa.Nome,
            Descricao = tarefa.Descricao
        });
    }
}
