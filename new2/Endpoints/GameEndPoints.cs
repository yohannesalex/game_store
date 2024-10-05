using System;
using Microsoft.VisualBasic;
using new2.Dtos;

namespace new2.Endpoints;

public static class GameEndPoints
{
    const string GameEndPoint = "GetGame";
    
    private static readonly List<GameDto> games =
    [
        new GameDto(
        1, "pubg", "action", 23.3M, new DateOnly(2021, 3, 3)
    ),
    new GameDto(
        2, "freefire", "action", 22.3M, new DateOnly(1903, 3, 3)
    ),
    new GameDto(
        3, "fifa", "football", 53.3M, new DateOnly(2203, 3, 3)
    ),
    new GameDto(
        4, "pes", "football", 93.3M, new DateOnly(2033, 3, 3)
    ),
    new GameDto(
        5, "DreamLeague", "football", 83.3M, new DateOnly(2094, 3, 3)
    )
    ];
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");
        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GameEndPoint);
        group.MapPost("/", (CreteGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);
            return Results.CreatedAtRoute(GameEndPoint, new { id = game.Id }, game);
        }

        ).WithParameterValidation();
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {

            GameDto updatedGame = new(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = updatedGame;


            return Results.NoContent();
        }).WithParameterValidation();
        group.MapDelete("/{id}", (int id) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games.RemoveAt(index);
            return Results.NoContent();
        }).WithParameterValidation();
        return group;
    }
}
