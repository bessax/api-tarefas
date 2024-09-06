
using consumo.api;
using System.Net.Http.Json;

var client = new HttpClient();

async Task ConsultaTarefas()
{
    var url = "http://localhost:5273/api/tarefa";
    var response = await client.GetAsync(url);
    var resultado = await response.Content.ReadFromJsonAsync<List<TarefaDTO>>();

    foreach (var item in resultado!)
    {
        Console.WriteLine(item);
    }
}

async Task CadastraTarefa()
{
    var url = "http://localhost:5273/api/tarefa";

    var tarefaDTO = new TarefaDTO() { 
          Id= Guid.NewGuid(),
          Descricao = "Tarefa de Teste",
          Nome="Teste"
         };

    var content = await client.PostAsJsonAsync<TarefaDTO>(url,tarefaDTO);

    var resultado = await content.Content.ReadAsStringAsync();

    Console.WriteLine(resultado);
  }

async Task ConsultaTarefaPorId()
{
    var url = "http://localhost:5273/api/tarefa/a4b0b31b-ddef-4788-a636-8727f55c583a";
    var response = await client.GetAsync(url);
    var resultado = await response.Content.ReadFromJsonAsync<TarefaDTO>();
       Console.WriteLine(resultado);

}

await CadastraTarefa();


