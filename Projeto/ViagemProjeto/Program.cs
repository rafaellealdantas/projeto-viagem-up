
using Microsoft.AspNetCore.Mvc;
using ViagemProjeto.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();


app.MapPost("/api/registro_voo/cadastrar", ([FromBody]Registro_Voo registro_Voo, [FromServices]AppDbContext ctx) =>
{
    ctx.Registro_Voos.Add(registro_Voo);
    ctx.SaveChanges();
    return Results.Created($"/registro_Voo/{registro_Voo.Id}", registro_Voo);
});


app.MapGet("/api/registro_voo/listar", ([FromServices]AppDbContext context) =>
{
    var Registro_Voos =  context.Registro_Voos.ToList();
    return Results.Ok(Registro_Voos);
});


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


app.Run();