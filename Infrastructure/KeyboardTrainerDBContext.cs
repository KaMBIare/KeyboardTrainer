using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using SQLitePCL;

namespace Infrastructure;

public class KeyboardTrainerDBContext : DbContext
{
    public DbSet<Level> Levels { get; set; }
    public DbSet<Session> Sessions { get; set; }
    
    public KeyboardTrainerDBContext()
    {
        SetProvider();
        Database.EnsureCreated();
    }

    private static bool _sqlitePCLInitialized = false;

    private static void SetProvider()
    {
        if (!_sqlitePCLInitialized)
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            _sqlitePCLInitialized = true;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=KeyboardTrainerDB.db");
    }
}
