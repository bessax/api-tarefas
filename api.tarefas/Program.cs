using api.tarefas;
using api.tarefas.Conversor;
using api.tarefas.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("api/tarefa", () =>
{
    var context = new TarefaContext();
    var listaDeTarefas = context.Tarefas.ToList();
    if (listaDeTarefas.Count == 0)
    {
        return Results.BadRequest("Lista de tarefas vazia!");
    }
    var conversor = new TarefaConverter();
    var listaDeTarefasDTO = conversor.EntityListToDtoList(listaDeTarefas);
   
    return Results.Ok(listaDeTarefasDTO);
}).WithTags("Tarefa").WithOpenApi();

app.MapGet("api/tarefa/{id}", (Guid id) =>
{
    var context = new TarefaContext();
    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null)
    {
        return Results.BadRequest("Tarefa não encontrada!");
    }
    var conversor = new TarefaConverter();
    var tarefaDTO = conversor.EntityToDto(tarefa);

    return Results.Ok(tarefaDTO);

}).WithTags("Tarefa").WithOpenApi();

app.MapPost("api/tarefa", (TarefaDTO dto) =>
{
    var context = new TarefaContext();
    var conversor = new TarefaConverter();  
    var tarefa = conversor.DtoToEntity(dto);
    context.Tarefas.Add(tarefa);
    context.SaveChanges();
    return Results.Ok("Tarefa adicionada com sucesso!");
}).WithTags("Tarefa").WithOpenApi();

app.MapDelete("api/tarefa", (Guid id) =>
{
    var context = new TarefaContext();
    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa == null)
    {
        return Results.BadRequest("Tarefa não encontrada!");
    }
    context.Tarefas.Remove(tarefa);
    context.SaveChanges();
    return Results.Ok("Tarefa removida com sucesso!");
}).WithTags("Tarefa").WithOpenApi();

app.MapPut("api/tarefa", (TarefaDTO dto) =>
{
    var context = new TarefaContext();
    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == dto.Id);
    if (tarefa == null)
    {
        return Results.BadRequest("Tarefa não encontrada!");
    }
    tarefa.Nome = dto.Nome;
    tarefa.Descricao = dto.Descricao;
    context.SaveChanges();
    return Results.Ok("Tarefa atualizada com sucesso!");
}).WithTags("Tarefa").WithOpenApi();

app.Run();


