
using Microsoft.AspNetCore.Mvc;
using ViagemProjeto.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

//Cadastrar um novo registro de viagem
app.MapPost("/api/registro_voo/cadastrar", ([FromBody] Voo registro_Voo, [FromServices] AppDbContext ctx) =>
{
    ctx.Voos.Add(registro_Voo);
    ctx.SaveChanges();
    return Results.Created($"/registro_Voo/{registro_Voo.Id}", registro_Voo);
});

//istar os registros de voos
app.MapGet("/api/registro_voo/listar", ([FromServices] AppDbContext ctx) =>
{
    var Voos = ctx.Voos.ToList();
    return Results.Ok(Voos);
});

//Atualizar os registros de voos
app.MapPut("/api/registro_voo/atualizar/{id}", ([FromRoute] int id, [FromBody] Voo registro_vooAtualizado, [FromServices] AppDbContext ctx) =>
{
    var registro_voo = ctx.Voos.Find(id);
    if (registro_voo == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    registro_voo.NumeroVoo = registro_vooAtualizado.NumeroVoo != 0 ? registro_vooAtualizado.NumeroVoo : registro_voo.NumeroVoo;
    registro_voo.Destino = registro_vooAtualizado.Destino ?? registro_voo.Destino;
    registro_voo.HrPartida = registro_vooAtualizado.HrPartida ?? registro_voo.HrPartida;
    registro_voo.HrChegadaPrevista = registro_vooAtualizado.HrChegadaPrevista ?? registro_voo.HrChegadaPrevista;
    registro_voo.TipoAviao = registro_vooAtualizado.TipoAviao ?? registro_voo.TipoAviao;
    registro_voo.Companhia = registro_vooAtualizado.Companhia ?? registro_voo.Companhia;
    registro_voo.TemProblema = registro_vooAtualizado.TemProblema;
    if (registro_vooAtualizado.TemProblema == true)
    {
        registro_voo.VooCancelado = true;
        ctx.SaveChanges();
        return Results.Ok("Voo cancelado.");
    }
    registro_voo.VooCancelado = false;
    ctx.SaveChanges();
    return Results.Ok("Registro atualizado com sucesso.");
});

//Deletar um registro de voo
app.MapDelete("/api/registro_voo/deletar/{id}", (int id, AppDbContext ctx) =>
{
    var registro_voo = ctx.Voos.Find(id);
    if (registro_voo == null)
    {
        return Results.NotFound("registro_voo não encontrado.");
    }

    ctx.Voos.Remove(registro_voo);
    ctx.SaveChanges();
    return Results.Ok("registro_voo removido com sucesso.");
});

//Cadastrar um novo membro da tripulaçao
app.MapPost("/api/registro_tripulacao/cadastrar", ([FromBody] Tripulacao registro_Tripulacao, [FromServices] AppDbContext ctx) =>
{
    ctx.Tripulacoes.Add(registro_Tripulacao);
    ctx.SaveChanges();
    return Results.Created($"/registro_tripulacao/{registro_Tripulacao.Id}", registro_Tripulacao);
});

//Listar toda a tripulaçao
app.MapGet("/api/registro_tripulacao/listar", ([FromServices] AppDbContext ctx) =>
{
    var Tripulacao = ctx.Tripulacoes.ToList();
    return Results.Ok(Tripulacao);
});

//Atualizar as informações de um membro da tripulaçao
app.MapPut("/api/registro_tripulacao/atualizar/{id}", (int id, Tripulacao registro_tripulacaoAtualizado, AppDbContext ctx) =>
{
    var registro_tripulacao = ctx.Tripulacoes.Find(id);
    if (registro_tripulacao == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    registro_tripulacao.Nome = registro_tripulacaoAtualizado.Nome ?? registro_tripulacao.Nome;
    registro_tripulacao.Cargo = registro_tripulacaoAtualizado.Cargo ?? registro_tripulacao.Cargo;
    registro_tripulacao.Funcao = registro_tripulacaoAtualizado.Funcao ?? registro_tripulacao.Funcao;
    registro_tripulacao.Qualificacoes = registro_tripulacaoAtualizado.Qualificacoes ?? registro_tripulacao.Qualificacoes;
    registro_tripulacao.HorarioTrabalho = registro_tripulacaoAtualizado.HorarioTrabalho ?? registro_tripulacao.HorarioTrabalho;
    registro_tripulacao.IdiomasFalados = registro_tripulacaoAtualizado.IdiomasFalados ?? registro_tripulacao.IdiomasFalados;
    ctx.SaveChanges();
    return Results.Ok("Membro da tripulação atualizado com sucesso.");
});

//Deletar um membro da tripulação
app.MapDelete("/api/registro_tripulacao/deletar/{id}", (int id, AppDbContext ctx) =>
{
    var registro_tripulacao = ctx.Tripulacoes.Find(id);
    if (registro_tripulacao == null)
    {
        return Results.NotFound("Membro da tripulação não encontrado.");
    }

    ctx.Tripulacoes.Remove(registro_tripulacao);
    ctx.SaveChanges();
    return Results.Ok("membro da tripulação removido com sucesso.");
});

//Verificacao climatica
app.MapPost("/api/verificacaoclimatica/cadastrar", async ([FromBody] VerificacaoClimatica verificacaoClimatica, [FromServices] AppDbContext ctx) =>
{
    ctx.VerificacoesClimaticas.Add(verificacaoClimatica);
    await ctx.SaveChangesAsync();
    return Results.Created($"/verificacaoclimatica/{verificacaoClimatica.Id}", verificacaoClimatica);
});

//listar Vericacao climatica
app.MapGet("/api/verificacaoclimatica/listar", ([FromServices] AppDbContext ctx) =>
{
    var VerificacoesClimaticas = ctx.VerificacoesClimaticas.ToList();
    return Results.Ok(VerificacoesClimaticas);
});

// Atualizar as verificações climáticas
app.MapPut("/api/verificacaoclimatica/atualizar/{id}", async ([FromRoute] int id, [FromBody] VerificacaoClimatica verificacaoClimaticaAtualizado, [FromServices] AppDbContext ctx) =>
{
    var verificacaoClimatica = await ctx.VerificacoesClimaticas.FindAsync(id);
    if (verificacaoClimatica == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    verificacaoClimatica.NumeroVoo = verificacaoClimaticaAtualizado.NumeroVoo != 0 ? verificacaoClimaticaAtualizado.NumeroVoo : verificacaoClimatica.NumeroVoo;
    verificacaoClimatica.RotaVoo = verificacaoClimaticaAtualizado.RotaVoo ?? verificacaoClimatica.RotaVoo;
    verificacaoClimatica.CondicoesMeteorologicas = verificacaoClimaticaAtualizado.CondicoesMeteorologicas ?? verificacaoClimatica.CondicoesMeteorologicas;
    verificacaoClimatica.PrevisaoTempo = verificacaoClimaticaAtualizado.PrevisaoTempo ?? verificacaoClimatica.PrevisaoTempo;
    verificacaoClimatica.AlertasTempestades = verificacaoClimaticaAtualizado.AlertasTempestades ?? verificacaoClimatica.AlertasTempestades;
    verificacaoClimatica.CondicoesAdversas = verificacaoClimaticaAtualizado.CondicoesAdversas ?? verificacaoClimatica.CondicoesAdversas;

    await ctx.SaveChangesAsync();
    return Results.Ok("Registro atualizado com sucesso.");
});

//Deletar uma verificacao climatica
app.MapDelete("/api/verificacaoclimatica/deletar/{id}", (int id, AppDbContext ctx) =>
{
    var verificacaoclimatica = ctx.VerificacoesClimaticas.Find(id);
    if (verificacaoclimatica == null)
    {
        return Results.NotFound("Verificacao climatica não encontrado.");
    }

    ctx.VerificacoesClimaticas.Remove(verificacaoclimatica);
    ctx.SaveChanges();
    return Results.Ok("Verificacao climatica removida com sucesso.");
});

app.Run();
