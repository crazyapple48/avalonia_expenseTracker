using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class HomePageViewModel() : PageViewModel(ApplicationPageNames.Home)
{
    [ObservableProperty]
    private string _welcomeMessage = "Welcome to Home Page!";

    [ObservableProperty] private ObservableCollection<string> _shortcuts = ["Gas", "Soda"];
}