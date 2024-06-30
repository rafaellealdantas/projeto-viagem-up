using Microsoft.AspNetCore.Mvc;
using ViagemProjeto.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

// Cadastrar um novo registro de viagem
app.MapPost("/api/registro_voo/cadastrar", ([FromBody] Voo registro_Voo, [FromServices] AppDbContext ctx) =>
{
    ctx.Voos.Add(registro_Voo);
    ctx.SaveChanges();
    return Results.Created($"/registro_voo/{registro_Voo.Id}", registro_Voo);
});

// Listar os registros de voos
app.MapGet("/api/registro_voo/listar", ([FromServices] AppDbContext ctx) =>
{
    var Voos = ctx.Voos.ToList();
    return Results.Ok(Voos);
});

// Buscar voo por id
app.MapGet("/api/voo/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDbContext ctx) =>
{
    //Expressão lambda em c#
    Voo? voo =
        ctx.Voos.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
    if (voo is null)
    {
        return Results.NotFound("voo não encontrado!");
    }
    return Results.Ok(voo);
});

// Atualizar os registros de voos
app.MapPut("/api/registro_voo/atualizar/{id}", ([FromRoute] int id, [FromBody] Voo registro_vooAtualizado, [FromServices] AppDbContext ctx) =>
{
    var registro_voo = ctx.Voos.Find(id);
    if (registro_voo == null)
        return Results.NotFound("Registro não encontrado.");

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

// Deletar um registro de voo
app.MapDelete("/api/registro_voo/deletar/{id}", (int id, AppDbContext ctx) =>
{
    var registro_voo = ctx.Voos.Find(id);
    if (registro_voo == null)
        return Results.NotFound("registro_voo não encontrado.");

    ctx.Voos.Remove(registro_voo);
    ctx.SaveChanges();
    return Results.Ok("registro_voo removido com sucesso.");
});

// Cadastrar um novo membro da tripulação
app.MapPost("/api/registro_tripulacao/cadastrar", ([FromBody] Tripulacao registro_Tripulacao, [FromServices] AppDbContext ctx) =>
{
    // Relacionamento da Tribulação com o Voo
    Voo? voo = ctx.Voos.Find(registro_Tripulacao.VooId);

    if (voo is null)
        return Results.NotFound("Voo não encontrado");

    registro_Tripulacao.Voo = voo;

    ctx.Tripulacoes.Add(registro_Tripulacao);
    ctx.SaveChanges();
    return Results.Created($"/registro_tripulacao/{registro_Tripulacao.Id}", registro_Tripulacao);
});

// Listar toda a tripulação
app.MapGet("/api/registro_tripulacao/listar", ([FromServices] AppDbContext ctx) =>
{
    var Tripulacao = ctx.Tripulacoes.Include(x => x.Voo).ToList();
    return Results.Ok(Tripulacao);
});

// Atualizar as informações de um membro da tripulação
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
    registro_tripulacao.VooId = registro_tripulacaoAtualizado.VooId > 0 ? registro_tripulacaoAtualizado.VooId : registro_tripulacao.VooId;
    ctx.SaveChanges();
    return Results.Ok("Membro da tripulação atualizado com sucesso.");
});

// Deletar um membro da tripulação
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

// Verificação climática
app.MapPost("/api/verificacaoclimatica/cadastrar", async ([FromBody] Clima verificacaoClimatica, [FromServices] AppDbContext ctx) =>
{
    Voo? voo = ctx.Voos.Find(verificacaoClimatica.VooId);

    if (voo is null)
        return Results.NotFound("Voo não encontrado");

    verificacaoClimatica.Voo = voo;

    ctx.Climas.Add(verificacaoClimatica);
    await ctx.SaveChangesAsync();
    return Results.Created($"/verificacaoclimatica/{verificacaoClimatica.Id}", verificacaoClimatica);
});

// Listar Verificação climática
app.MapGet("/api/verificacaoclimatica/listar", ([FromServices] AppDbContext ctx) =>
{
    var VerificacoesClimaticas = ctx.Climas.Include(x => x.Voo).ToList();
    return Results.Ok(VerificacoesClimaticas);
});



// Atualizar as verificações climáticas
app.MapPut("/api/verificacaoclimatica/atualizar/{id}", async ([FromRoute] int id, [FromBody] Clima verificacaoClimaticaAtualizado, [FromServices] AppDbContext ctx) =>
{
    var verificacaoClimatica = await ctx.Climas.FindAsync(id);
    if (verificacaoClimatica == null)
    {
        return Results.NotFound("Registro não encontrado.");
    }

    verificacaoClimatica.CondicoesMeteorologicas = verificacaoClimaticaAtualizado.CondicoesMeteorologicas ?? verificacaoClimatica.CondicoesMeteorologicas;
    verificacaoClimatica.PrevisaoTempo = verificacaoClimaticaAtualizado.PrevisaoTempo ?? verificacaoClimatica.PrevisaoTempo;
    verificacaoClimatica.AlertasTempestades = verificacaoClimaticaAtualizado.AlertasTempestades ?? verificacaoClimatica.AlertasTempestades;
    verificacaoClimatica.CondicoesAdversas = verificacaoClimaticaAtualizado.CondicoesAdversas ?? verificacaoClimatica.CondicoesAdversas;
    verificacaoClimatica.VooId = verificacaoClimaticaAtualizado.VooId > 0 ? verificacaoClimaticaAtualizado.VooId : verificacaoClimatica.VooId;

    await ctx.SaveChangesAsync();
    return Results.Ok("Registro atualizado com sucesso.");
});

// Deletar uma verificação climática
app.MapDelete("/api/verificacaoclimatica/deletar/{id}", (int id, AppDbContext ctx) =>
{
    var verificacaoclimatica = ctx.Climas.Find(id);
    if (verificacaoclimatica == null)
    {
        return Results.NotFound("Verificação climática não encontrado.");
    }

    ctx.Climas.Remove(verificacaoclimatica);
    ctx.SaveChanges();
    return Results.Ok("Verificação climática removida com sucesso.");
});

// Cadastrar um novo passageiro
app.MapPost("/api/registro_passageiro/cadastrar", async ([FromBody] Passageiro registro_Passageiro, [FromServices] AppDbContext ctx) =>
{
    Voo? voo = ctx.Voos.Find(registro_Passageiro.VooId);

    if (voo is null)
        return Results.NotFound("Voo não encontrado");

    registro_Passageiro.Voo = voo;

    ctx.Passageiros.Add(registro_Passageiro);
    await ctx.SaveChangesAsync();
    return Results.Created($"/registro_passageiro/{registro_Passageiro.Id}", registro_Passageiro);
});

// Listar todos os passageiros
app.MapGet("/api/registro_passageiro/listar", async ([FromServices] AppDbContext ctx) =>
{
    var passageiros = await ctx.Passageiros.Include(x => x.Voo).ToListAsync();
    return Results.Ok(passageiros);
});

// Atualizar as informações de um passageiro
app.MapPut("/api/registro_passageiro/atualizar/{id}", async ([FromRoute] int id, [FromBody] Passageiro passageiroAtualizado, [FromServices] AppDbContext ctx) =>
{
    var passageiro = await ctx.Passageiros.FindAsync(id);
    if (passageiro == null)
    {
        return Results.NotFound("Passageiro não encontrado.");
    }

    passageiro.Nome = passageiroAtualizado.Nome ?? passageiro.Nome;
    passageiro.Sobrenome = passageiroAtualizado.Sobrenome ?? passageiro.Sobrenome;
    passageiro.DataNascimento = passageiroAtualizado.DataNascimento != default ? passageiroAtualizado.DataNascimento : passageiro.DataNascimento;
    passageiro.Passaporte = passageiroAtualizado.Passaporte ?? passageiro.Passaporte;
    passageiro.Nacionalidade = passageiroAtualizado.Nacionalidade ?? passageiro.Nacionalidade;
    passageiro.VooId = passageiroAtualizado.VooId > 0 ? passageiroAtualizado.VooId : passageiro.VooId;


    await ctx.SaveChangesAsync();
    return Results.Ok("Passageiro atualizado com sucesso.");
});

// Deletar um passageiro
app.MapDelete("/api/registro_passageiro/deletar/{id}", ([FromRoute] int id, [FromServices] AppDbContext ctx) =>
{
    var passageiro = ctx.Passageiros.Find(id);
    if (passageiro == null)
    {
        return Results.NotFound("Passageiro não encontrado.");
    }

    ctx.Passageiros.Remove(passageiro);
    ctx.SaveChanges();
    return Results.Ok("Passageiro removido com sucesso.");
});

app.MapPost("/api/carga/cadastrar", ([FromBody] Carga registroCarga, [FromServices] AppDbContext ctx) =>
{
    Passageiro? passageiro = ctx.Passageiros.Find(registroCarga.PassageiroId);

    if (passageiro is null)
        return Results.NotFound("Voo não encontrado");

    registroCarga.Passageiro = passageiro;

    ctx.Cargas.Add(registroCarga);
    ctx.SaveChanges();
    return Results.Created($"/carga/{registroCarga.Id}", registroCarga);
});

// Listar todos os passageiros
app.MapGet("/api/carga/listar", ([FromServices] AppDbContext ctx) =>
{
    var carga = ctx.Cargas.Include(x => x.Passageiro).ToList();
    return Results.Ok(carga);
});

// Atualizar as informações de um passageiro
app.MapPut("/api/carga/atualizar/{id}", ([FromRoute] int id, [FromBody] Carga cargaAtualizada, [FromServices] AppDbContext ctx) =>
{
    var carga = ctx.Cargas.Find(id);
    if (carga == null)
    {
        return Results.NotFound("Carga não encontrada.");
    }

    carga.Peso = cargaAtualizada.Peso <= 0 ? carga.Peso : cargaAtualizada.Peso;
    carga.Descricao = cargaAtualizada.Descricao ?? null;
    carga.CargaPrioritaria = cargaAtualizada.CargaPrioritaria;
    carga.CargaComercial = cargaAtualizada.CargaComercial;
    carga.PassageiroId = cargaAtualizada.PassageiroId != 0 ? cargaAtualizada.PassageiroId : carga.PassageiroId;;

    ctx.SaveChanges();
    return Results.Ok("Carga atualizada com sucesso.");
});

// Deletar um passageiro
app.MapDelete("/api/carga/deletar/{id}", async ([FromRoute] int id, [FromServices] AppDbContext ctx) =>
{
    var carga = await ctx.Cargas.FindAsync(id);
    if (carga == null)
    {
        return Results.NotFound("Carga não encontrada.");
    }

    ctx.Cargas.Remove(carga);
    await ctx.SaveChangesAsync();
    return Results.Ok("Carga removida com sucesso.");
});

app.UseCors("Acesso Total");
app.Run();