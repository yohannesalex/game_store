using System;
using Microsoft.EntityFrameworkCore;

namespace new2.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{

}
