using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class ReportsPageViewModel() : PageViewModel(ApplicationPageNames.Reports)
{
    // TODO: Implement Reports Page

    [ObservableProperty] private string _reportsMessage = "This Page is not implemented yet.";
}