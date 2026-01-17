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

        return shortcuts.Count == 0 ? null : shortcuts;
    }

    public bool CreateShortcut(ShortcutDataModel? shortcut)
    {
        if (shortcut is null) return false;
        _context.Shortcuts.Add(shortcut);

        var result = _context.SaveChanges();

        return result > 0;
    }
}