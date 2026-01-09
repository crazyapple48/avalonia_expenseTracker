using System;
using ExpenseTracker.MainApp;
using ExpenseTracker.Services;
using ExpenseTracker.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Bootstrap;

public static class Bootstrapper
{
    public static void RegisterCommonServices(IServiceCollection collection)
    {
        // Singleton Services
        collection.AddSingleton<MainViewModel>();

        // Page Factory Callback
        collection.AddSingleton<Func<Type, PageViewModel>>(x => type => type switch
        {
            _ when type == typeof(HomePageViewModel) => x.GetRequiredService<HomePageViewModel>(),
            _ when type == typeof(ReportsPageViewModel) => x.GetRequiredService<ReportsPageViewModel>(),
            _ => throw new InvalidOperationException($"No PageViewModel registered for type {type}")
        });

        // Page Factory
        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<DialogService>();

        // Add Transients
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<ReportsPageViewModel>();
    }
}