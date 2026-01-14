using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;
using ExpenseTracker.ViewModels.Base;

namespace ExpenseTracker.ViewModels.Pages;

public partial class ReportsPageViewModel() : PageViewModel(ApplicationPageNames.Reports)
{
    // TODO: Implement Reports Page

    [ObservableProperty] private string _reportsMessage = "This Page is not implemented yet.";
}