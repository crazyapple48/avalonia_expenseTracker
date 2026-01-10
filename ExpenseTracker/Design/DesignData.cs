using System;
using ExpenseTracker.Bootstrap;
using ExpenseTracker.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Design;

public static class DesignData
{
    private static readonly IServiceProvider Services;

    static DesignData()
    {
        var collection = new ServiceCollection();

        // Register common services
        Bootstrapper.RegisterCommonServices(collection);

        // Build design-time service provider
        Services = collection.BuildServiceProvider();
    }

    public static MainViewModel MainViewModel => Services.GetRequiredService<MainViewModel>();

    public static HomePageViewModel HomePageViewModel => Services.GetRequiredService<HomePageViewModel>();

    public static ReportsPageViewModel ReportsPageViewModel => Services.GetRequiredService<ReportsPageViewModel>();

    public static SubmitExpenseDialogViewModel SubmitExpenseDialogViewModel =>
        Services.GetRequiredService<SubmitExpenseDialogViewModel>();
}