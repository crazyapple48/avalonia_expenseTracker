using System;
using System.IO;
using Avalonia;
using ExpenseTracker.DataStorage.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DataStorage;

public class ApplicationDbContext : DbContext
{
    public DbSet<ShortcutDataModel> Shortcuts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string storagePath;
#if DEBUG
        if (OperatingSystem.IsWindows())
        {
            storagePath = @"D:\data\ExpenseTracker";
        }
        else
        {
            // Debugging on Linux
            storagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ExpenseTracker");
        }
#else
        // production paths
        storagePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ExpenseTracker");
#endif
        Directory.CreateDirectory(storagePath);

        optionsBuilder.UseSqlite(
            $"Data Source={Path.Combine(storagePath, "data.db")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortcutDataModel>().HasKey(f => f.Id);
    }
}