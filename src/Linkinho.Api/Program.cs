using Linkinho.Domain.Contracts.Service;
using Linkinho.Domain.Services;
using Linkinho.Infra.Repos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.AddRepository();

builder.Services.AddTransient<ILinkService, LinkService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();


app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
await app.UseRepository();

app.MapGet("/{idLink:length(6)}", async ([FromRoute] string idLink, [FromServices] ILinkService linkService) =>
{
    try
    {
        var urlToRedirect = await linkService.GetUrlToRedirect(idLink);

        if (string.IsNullOrEmpty(urlToRedirect))
            return Results.NotFound();

        return Results.Redirect(urlToRedirect, true);
    }
    catch (Exception e)
    {
        return Results.BadRequest(e);
    }
})
.WithName("Redirect");

app.MapPost("/RegisterNewRote", async ([FromBody] string idLink, [FromServices] ILinkService linkService) =>
{
    try
    {
        var link = await linkService.CreateLink("http://google.com");

        return Results.Created($"/{link.Identificator}", link);
    }
    catch (Exception e)
    {
        return Results.BadRequest(e);
    }
})
.WithName("Register");

app.Run();

