
using Microsoft.AspNetCore.Mvc;
using ViagemProjeto.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

//Cadastrar um novo registro de viagem
app.MapPost("/api/registro_voo/cadastrar", ([FromBody]Registro_Voo registro_Voo, [FromServices]AppDbContext ctx) =>
{
    ctx.Registro_Voos.Add(registro_Voo);
    ctx.SaveChanges();
    return Results.Created($"/registro_Voo/{registro_Voo.Id}", registro_Voo);
});

//istar os registros de voos
app.MapGet("/api/registro_voo/listar", ([FromServices]AppDbContext context) =>
{
    var Registro_Voos =  context.Registro_Voos.ToList();
    return Results.Ok(Registro_Voos);
});

//Atualizar os registros de voos
app.MapPut("/api/registro_voo/atualizar/{id}",  (int id, Registro_Voo registro_vooAtualizado, AppDbContext context) =>
{
    var registro_voo = context.Registro_Voos.Find(id);
    if (registro_voo == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    registro_voo.NumeroVoo = registro_vooAtualizado.NumeroVoo;
    registro_voo.Destino = registro_vooAtualizado.Destino;
    registro_voo.HrPartida = registro_vooAtualizado.HrPartida;
    registro_voo.HrChegadaPrevista = registro_vooAtualizado.HrChegadaPrevista;
    registro_voo.TipoAviao = registro_vooAtualizado.TipoAviao;
    registro_voo.Companhia = registro_vooAtualizado.Companhia;
     context.SaveChanges();
    return Results.Ok("Registro atualizado com sucesso.");
});

//Deletar um registro de voo
app.MapDelete("/api/registro_voo/deletar/{id}",  (int id, AppDbContext context) =>
{
    var registro_voo = context.Registro_Voos.Find(id);
    if (registro_voo == null)
    {
        return Results.NotFound("registro_voo não encontrado.");
    }

    context.Registro_Voos.Remove(registro_voo);
    context.SaveChanges();
    return Results.Ok("registro_voo removido com sucesso.");
});

//Cadastrar um novo membro da tripulaçao
app.MapPost("/api/registro_tripulacao/cadastrar", ([FromBody]Registro_Tripulacao registro_Tripulacao, [FromServices]AppDbContext ctx) =>
{
    ctx.Registro_Tripulacoes.Add(registro_Tripulacao);
    ctx.SaveChanges();
    return Results.Created($"/registro_tripulacao/{registro_Tripulacao.Id}", registro_Tripulacao);
});

//Listar toda a tripulaçao
app.MapGet("/api/registro_tripulacao/listar", ([FromServices]AppDbContext context) =>
{
    var Registro_Tripulacao =  context.Registro_Tripulacoes.ToList();
    return Results.Ok(Registro_Tripulacao);
});

//Atualizar as informações de um membro da tripulaçao
app.MapPut("/api/registro_tripulacao/atualizar/{id}",  (int id, Registro_Tripulacao registro_tripulacaoAtualizado, AppDbContext context) =>
{
    var registro_tripulacao = context.Registro_Tripulacoes.Find(id);
    if (registro_tripulacao == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    registro_tripulacao.Nome = registro_tripulacaoAtualizado.Nome;
    registro_tripulacao.Cargo = registro_tripulacaoAtualizado.Cargo;
    registro_tripulacao.Funcao = registro_tripulacaoAtualizado.Funcao;
    registro_tripulacao.Qualificacoes = registro_tripulacaoAtualizado.Qualificacoes;
    registro_tripulacao.HorarioTrabalho = registro_tripulacaoAtualizado.HorarioTrabalho;
    registro_tripulacao.IdiomasFalados = registro_tripulacaoAtualizado.IdiomasFalados;
     context.SaveChanges();
    return Results.Ok("Membro da tripulação atualizado com sucesso.");
});

//Deletar um membro da tripulação
app.MapDelete("/api/registro_tripulacao/deletar/{id}",  (int id, AppDbContext context) =>
{
    var registro_tripulacao = context.Registro_Tripulacoes.Find(id);
    if (registro_tripulacao == null)
    {
        return Results.NotFound("Membro da tripulação não encontrado.");
    }

    context.Registro_Tripulacoes.Remove(registro_tripulacao);
    context.SaveChanges();
    return Results.Ok("membro da tripulação removido com sucesso.");
});


app.Run();