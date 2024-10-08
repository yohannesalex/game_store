using System;
using Microsoft.EntityFrameworkCore;
using new2.Entities;

namespace new2.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
  public DbSet<Game> Games { get; set; }
  public DbSet<Genre> Genres { get; set; }
}
