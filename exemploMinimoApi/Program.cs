using exemploMinimoApi.Model;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

using System;

var builder = WebApplication.CreateBuilder(args);
await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));


app.MapPost("/api/v1/inserirProduto", (Func<Produto, IActionResult>)((Produto produto) =>
{
    //logica para inserir na base de dados
    return new OkResult();
}));

app.MapPut("/api/v1/editarProduto/{id}", (Func<Produto, int, IActionResult>)((Produto produto, int id) =>
{
    //logica .....
    return new OkResult();
}));

app.MapDelete("/api/v1/deletarProduto/{id}", ((Func<int, IActionResult>)((int id) => 
{
    //lógica para deletar o produto, recuperando o id passado
    return new NoContentResult();
})));


await app.RunAsync();
