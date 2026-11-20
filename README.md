# ✅ API de Tarefas
 
**Minimal API** em **.NET 8** para gerenciamento de tarefas, com persistência em **SQL Server** via **Entity Framework Core**, documentação com **Swagger** e um **aplicativo de console** que demonstra como consumir a API usando `HttpClient`.
 
---
 
## ✨ Funcionalidades
 
- Cadastro, listagem, consulta por id, atualização e exclusão de tarefas.
- Identificador do tipo **`Guid`**, gerado automaticamente.
- Cada nova tarefa nasce com **data de início** (agora) e **status `Iniciado`**.
- Separação entre **entidade** (`Tarefa`) e **DTO** (`TarefaDTO`), com uma classe conversora.
- **Migrations** do EF Core para criar a estrutura do banco.
- Documentação interativa com **Swagger**.
- Projeto de console (`consumo.api`) com exemplos de consumo da API.
## 🧰 Tecnologias
 
| Tecnologia | Uso |
|---|---|
| C# e .NET 8 | Linguagem e plataforma |
| ASP.NET Core Minimal API | Construção dos endpoints |
| Entity Framework Core 8 + SQL Server | Acesso a dados (ORM) e banco |
| Swashbuckle (Swagger) | Documentação e testes da API |
| `HttpClient` | Consumo da API no projeto de console |
 
## 📁 Estrutura da solução
 
```
api.tarefas.sln
├── api.tarefas/                 # A API
│   ├── Program.cs               # Configuração e endpoints
│   ├── Modelos/Tarefa.cs        # Entidade Tarefa e enum Status
│   ├── DTO/TarefaDTO.cs         # Objeto de transferência de dados
│   ├── Conversor/               # TarefaConverter (entidade ↔ DTO)
│   ├── Context/TarefaContext.cs # DbContext (SQL Server)
│   ├── Migrations/              # Migrations do EF Core
│   └── api.tarefas.http         # Requisição de exemplo
└── consumo.api/                 # Aplicativo de console que consome a API
    ├── Program.cs               # Exemplos de chamadas HTTP
    └── TarefaDTO.cs
```
 
## ✅ Pré-requisitos
 
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server ou **SQL Server LocalDB** (instalado junto com o Visual Studio, no Windows)
- Ferramenta do EF Core:
```bash
dotnet tool install --global dotnet-ef
```
 
## 🚀 Como executar
 
### 1. Clone o repositório
 
```bash
git clone https://github.com/<seu-usuario>/api-tarefas.git
cd api-tarefas
```
 
### 2. Configure o banco de dados
 
A string de conexão está definida na classe `api.tarefas/Context/TarefaContext.cs` e, por padrão, usa o **LocalDB**, com o banco `TarefasBD`:
 
```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TarefasBD;Integrated Security=True;...
```
 
Se usar outra instância do SQL Server, altere esse valor.
 
### 3. Crie o banco (Migrations)
 
```bash
cd api.tarefas
dotnet ef database update
```
 
### 4. Execute a API
 
```bash
dotnet run --launch-profile https
```
 
- Swagger: `https://localhost:7109/swagger`
- HTTP: `http://localhost:5273/swagger`
## 📡 Endpoints
 
| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/tarefa` | Lista todas as tarefas |
| `GET` | `/api/tarefa/{id}` | Obtém uma tarefa pelo `Guid` |
| `POST` | `/api/tarefa` | Cadastra uma nova tarefa |
| `PUT` | `/api/tarefa` | Atualiza nome e descrição (id no corpo) |
| `DELETE` | `/api/tarefa?id={guid}` | Remove uma tarefa (id na *query string*) |
 
### Modelo de dados
 
**Tarefa** (tabela `Tarefas`)
 
| Campo | Tipo | Observação |
|---|---|---|
| `Id` | `Guid` | Gerado automaticamente |
| `Nome` | `string` | |
| `Descricao` | `string` | |
| `DataInicio` | `DateTime` | Definida na criação |
| `DataFim` | `DateTime` | |
| `Status` | enum | `Iniciado`, `EmAndamento`, `Concluido` ou `Cancelado` |
 
O **DTO** expõe apenas `Id`, `Nome` e `Descricao`.
 
### Exemplos
 
**Cadastrar uma tarefa**
 
```http
POST http://localhost:5273/api/tarefa
Content-Type: application/json
 
{
  "nome": "Estudar .NET",
  "descricao": "Praticar Minimal APIs com EF Core"
}
```
 
**Atualizar uma tarefa**
 
```http
PUT http://localhost:5273/api/tarefa
Content-Type: application/json
 
{
  "id": "a4b0b31b-ddef-4788-a636-8727f55c583a",
  "nome": "Estudar .NET 8",
  "descricao": "Descrição atualizada"
}
```
 
**Excluir uma tarefa**
 
```http
DELETE http://localhost:5273/api/tarefa?id=a4b0b31b-ddef-4788-a636-8727f55c583a
```
 
## 🖥️ Projeto de consumo (`consumo.api`)
 
Aplicativo de console que mostra como chamar a API com `HttpClient` e `System.Net.Http.Json`, com funções para consultar, cadastrar, atualizar e excluir tarefas. Com a API em execução:
 
```bash
dotnet run --project consumo.api
```
 
A URL base usada no código é `http://localhost:5273`. Por padrão, o `Program.cs` executa apenas o cadastro (`CadastraTarefa`), e você pode trocar a chamada final para testar as demais.
 
## 🗺️ Próximos passos
 
- [ ] Ajustar as chamadas de atualização e exclusão do `consumo.api`: elas usam `/api/tarefa/1`, mas a API espera o `id` no corpo (`PUT`) e na *query string* (`DELETE`).
- [ ] Mover a string de conexão para o `appsettings.json` e registrar o `DbContext` via injeção de dependência.
- [ ] Expor `Status`, `DataInicio` e `DataFim` no DTO e permitir atualizá-los.
- [ ] Retornar códigos HTTP mais adequados (`201 Created`, `404 Not Found`, `204 No Content`). Hoje tarefa não encontrada e lista vazia retornam `400`.
- [ ] Validar os dados de entrada (por exemplo, `Nome` obrigatório).
- [ ] Usar operações assíncronas no acesso ao banco (`ToListAsync`, `SaveChangesAsync`).
- [ ] Adicionar testes automatizados.
## 📄 Licença
 
Defina aqui a licença do projeto (por exemplo, [MIT](https://opensource.org/licenses/MIT)).
 
---
 
Feito com 💙 durante os estudos de **APIs com .NET**.
 
