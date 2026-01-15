using System;
using System.IO;
using ExpenseTracker.DataStorage.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DataStorage;

public class ApplicationDbContext : DbContext
{
    public DbSet<ShortcutDataModel> Shortcuts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ensure folder exists
        var storagePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Expense Tracker");
        Directory.CreateDirectory(storagePath);

        optionsBuilder.UseSqlite(
            $"Data Source={Path.Combine(storagePath, "settings.db")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortcutDataModel>().HasKey(f => f.Name);
    }
}