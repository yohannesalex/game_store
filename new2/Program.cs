
using new2.Data;
using new2.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString  = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();
app.MapGamesEndpoints();
app.Run();
