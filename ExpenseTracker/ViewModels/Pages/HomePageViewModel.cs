using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.DataStorage;
using ExpenseTracker.MainApp;
using ExpenseTracker.Services;
using ExpenseTracker.ViewModels.Base;
using ExpenseTracker.ViewModels.Dialogs;
using ExpenseTracker.ViewModels.Models;

namespace ExpenseTracker.ViewModels.Pages;

public partial class HomePageViewModel(
    MainViewModel mainViewModel,
    DialogService dialogService,
    DatabaseFactory databaseFactory)
    : PageViewModel(ApplicationPageNames.Home)
{
    [ObservableProperty] private string _welcomeMessage = "Welcome to Home Page!";

    [ObservableProperty] private ObservableCollection<ShortcutViewModel>? _shortcuts;

    [ObservableProperty] private ShortcutViewModel? _selectedShortcut;

    [RelayCommand]
    private void Initialize()
    {
        var dbContext = databaseFactory.GetDatabaseService();

        var shortcuts = dbContext.GetShortcuts()?.Select(f => new ShortcutViewModel
        {
            Name = f.Name, Id = f.Id, Amount = f.Amount, Location = f.Location, NickName = f.NickName,
            PaymentMethod = f.PaymentMethod, Reason = f.Reason
        }).OrderBy(x => x.Name).ToList();
        if (shortcuts != null)
            Shortcuts = new ObservableCollection<ShortcutViewModel>(shortcuts);
    }

    [RelayCommand]
    private async Task ShowCreateExpenseDialogAsync(ShortcutViewModel? selectedShortcut = null)
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