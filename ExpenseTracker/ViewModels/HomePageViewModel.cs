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

    [ObservableProperty] private ObservableCollection<SelectedShortcutViewModel> _shortcuts =
        [new SelectedShortcutViewModel(), new SelectedShortcutViewModel { Name = "Soda" }];

    [ObservableProperty] private SelectedShortcutViewModel? _selectedShortcut;

    public HomePageViewModel() : this(new MainViewModel(), new DialogService())
    {
    }

    [RelayCommand]
    public async Task CreateExpenseAsync(SelectedShortcutViewModel? selectedShortcut = null)
    {
        if (selectedShortcut is null) return;
        var submitExpenseDialogViewModel = new SubmitExpenseDialogViewModel
        {
            Name = selectedShortcut.Name,
            Amount = selectedShortcut.Amount,
            Location = selectedShortcut.Location,
        };


        await dialogService.ShowDialog(mainViewModel, submitExpenseDialogViewModel);
    }
}