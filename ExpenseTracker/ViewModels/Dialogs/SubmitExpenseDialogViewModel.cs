using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.DataStorage;
using ExpenseTracker.DataStorage.DataModels;

namespace ExpenseTracker.ViewModels.Dialogs;

public partial class SubmitExpenseDialogViewModel(DatabaseFactory factory) : DialogViewModel
{
    [ObservableProperty] private string _name = "";
    [ObservableProperty] private string? _location;
    [ObservableProperty] private string? _defaultLocation;
    [ObservableProperty] private double? _amount;
    [ObservableProperty] private double? _defaultAmount;
    [ObservableProperty] private string? _nickName;
    [ObservableProperty] private string? _defaultNickName;
    [ObservableProperty] private string? _reason;
    [ObservableProperty] private string? _defaultReason;
    [ObservableProperty] private string? _paymentMethod;
    [ObservableProperty] private string? _defaultPaymentMethod;

    [ObservableProperty] private string _title = "Submit Expense";
    [ObservableProperty] private string _submitText = "Submit";
    [ObservableProperty] private string _cancelText = "Cancel";
    [ObservableProperty] private string _iconText = "";

    [ObservableProperty] private bool _submitSucceeded;
    [ObservableProperty] private bool _submitting;
    [ObservableProperty] private string? _error;

    [ObservableProperty] private bool _isShortcut;
    [ObservableProperty] private bool _canCreateShortcut;

    [ObservableProperty] private bool _isLocationDefault;
    [ObservableProperty] private bool _isAmountDefault;
    [ObservableProperty] private bool _isNickNameDefault;
    [ObservableProperty] private bool _isReasonDefault;
    [ObservableProperty] private bool _isPaymentMethodDefault;


    [RelayCommand]
    private void Submit()
    {
        Submitting = true;
        var context = factory.GetDatabaseService();

        if (CanCreateShortcut)
        {
            var result = context.CreateShortcut(new ShortcutDataModel
            {
                Name = Name,
                Location = Location,
                Amount = Amount,
                NickName = NickName,
                Reason = Reason,
                PaymentMethod = PaymentMethod
            });

            if (!result)
            {
                Error = "Something went wrong submitting, please try again";
                Submitting = false;
                return;
            }
        }

        SubmitSucceeded = true;
        Submitting = false;
        Close();
    }

    [RelayCommand]
    private void Cancel()
    {
        SubmitSucceeded = false;

        Close();
    }

    [RelayCommand]
    private void Initialize()
    {
        Amount = DefaultAmount;
        Location = DefaultLocation;
        NickName = DefaultNickName;
        PaymentMethod = DefaultPaymentMethod;
        Reason = DefaultReason;
    }
}