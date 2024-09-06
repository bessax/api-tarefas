using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumo.api;

public class TarefaDTO
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }

    public override string ToString()
    {
        return $"ID= {Id} - Nome= {Nome} - Descrição= {Descricao}";
    }
}

