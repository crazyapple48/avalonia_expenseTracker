using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.DataStorage.DataModels;

namespace ExpenseTracker.DataStorage;

public class DatabaseService(ApplicationDbContext context) : IDisposable
{
    private readonly ApplicationDbContext _context = context;

    public void Dispose() => _context.Dispose();

    public void ApplyMigrations()
    {
        // TODO: Change to migrations once we start persisting data
        _context.Database.EnsureCreated();
    }

    public List<ShortcutDataModel>? GetShortcuts()
    {
        var shortcuts = _context.Shortcuts.ToList();

        if (shortcuts.Count == 0) _context.Shortcuts.Add(new ShortcutDataModel { Name = "Default" });

        _context.SaveChanges();

        return shortcuts;
    }

    public void CreateShortcut(ShortcutDataModel? shortcut)
    {
        if (shortcut is null) return;
        _context.Shortcuts.Add(shortcut);
    }
}