using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.MainApp;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.ViewModels.Base;
using ExpenseTracker.ViewModels.Dialogs;

namespace ExpenseTracker.ViewModels.Pages;

public partial class HomePageViewModel(MainViewModel mainViewModel, DialogService dialogService)
    : PageViewModel(ApplicationPageNames.Home)
{
    [ObservableProperty] private string _welcomeMessage = "Welcome to Home Page!";

    [ObservableProperty] private ObservableCollection<ShortcutModel> _shortcuts =
    [
        new ShortcutModel
        {
            Name = "Gas", Amount = 54.75,
            Location = "Home",
            Reason = "Food",
            NickName = "Jane",
            PaymentMethod = "Cash"
        },
        new ShortcutModel { Name = "Soda" }
    ];

    [ObservableProperty] private ShortcutModel? _selectedShortcut;

    public HomePageViewModel() : this(new MainViewModel(), new DialogService())
    {
    }

    [RelayCommand]
    private async Task ShowCreateExpenseDialogAsync(ShortcutModel? selectedShortcut = null)
    {
        if (selectedShortcut is null)
        {
            var submitExpenseDialogViewModel = new SubmitExpenseDialogViewModel();

            await dialogService.ShowDialog(mainViewModel, submitExpenseDialogViewModel);
        }
        else
        {
            var submitExpenseDialogViewModel = new SubmitExpenseDialogViewModel
            {
                Name = selectedShortcut.Name,
                DefaultAmount = selectedShortcut.Amount,
                DefaultLocation = selectedShortcut.Location,
                DefaultReason = selectedShortcut.Reason,
                DefaultNickName = selectedShortcut.NickName,
                DefaultPaymentMethod = selectedShortcut.PaymentMethod,
                IsShortcut = true,
            };

            await dialogService.ShowDialog(mainViewModel, submitExpenseDialogViewModel);
        }
    }
}