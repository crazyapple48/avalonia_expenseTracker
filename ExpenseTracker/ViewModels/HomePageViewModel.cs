using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class HomePageViewModel() : PageViewModel(ApplicationPageNames.Home)
{
    [ObservableProperty]
    private string _welcomeMessage = "Welcome to Home Page!";
}