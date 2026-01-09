using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.MainApp;
using ExpenseTracker.Services;

namespace ExpenseTracker.ViewModels;

public partial class HomePageViewModel(MainViewModel mainViewModel, DialogService dialogService)
    : PageViewModel(ApplicationPageNames.Home)
{
    [ObservableProperty] private string _welcomeMessage = "Welcome to Home Page!";

    [ObservableProperty] private ObservableCollection<string> _shortcuts = ["Gas", "Soda"];

    [RelayCommand]
    public async Task CreateExpenseAsync()
    {
        var submitExpenseDialogViewModel = new SubmitExpenseDialogViewModel
        {
            Name = "Gas"
        };

        await dialogService.ShowDialog(mainViewModel, submitExpenseDialogViewModel);
    }
}