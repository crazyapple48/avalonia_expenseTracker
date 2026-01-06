using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class ReportsPageViewModel() : PageViewModel(ApplicationPageNames.Reports)
{
    [ObservableProperty]
    private string _reportsMessage = "Reports Page!";
}