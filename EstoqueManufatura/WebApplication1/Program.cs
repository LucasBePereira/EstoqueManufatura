using EstoqueManufatua_API.EndPoints;
using EstoqueManufatura.Sahred.Models;
using EstoqueManufatura.Shared.Data.BD;
using EstoqueManufatura.Shared.Data.Models;
using EstoqueManufatura_Console;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<Context>();
builder.Services.AddTransient<DAL<Componente>>();
builder.Services.AddTransient<DAL<Projeto>>();
builder.Services.AddTransient<DAL<Estoque>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<AccessUser>
().AddEntityFrameworkStores<Context>();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();

app.AddEndpointsComponente();
app.AddEndpointsProjeto();
app.AddEndpointsEstoque();

app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser>
    manager) =>
{
    await manager.SignOutAsync();
    return Results.Ok("Usuário deslogado com sucesso.");
}
);

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
