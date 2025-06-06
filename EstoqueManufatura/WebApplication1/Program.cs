using EstoqueManufatua_API.EndPoints;
using EstoqueManufatura.Sahred.Models;
using EstoqueManufatura.Shared.Data.BD;
using EstoqueManufatura_Console;
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

var app = builder.Build();

app.AddEndpointsComponente();
app.AddEndpointsProjeto();
app.AddEndpointsEstoque();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
