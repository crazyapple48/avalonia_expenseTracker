using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExpenseTracker.ViewModels;

public partial class SubmitExpenseDialogViewModel : DialogViewModel
{
    [ObservableProperty] private string _name = "";
    [ObservableProperty] private string? _location;
    [ObservableProperty] private double? _amount;
    [ObservableProperty] private string? _nickName;
    [ObservableProperty] private string? _reason;
    [ObservableProperty] private string? _paymentMethod;

    [ObservableProperty] private string _title = "Submit Expense";
    [ObservableProperty] private string _submitText = "Submit";
    [ObservableProperty] private string _cancelText = "Cancel";
    [ObservableProperty] private string _iconText = "";

    [ObservableProperty] private bool _submitSucceeded;
    [ObservableProperty] private bool _submitting;


    [RelayCommand]
    public void Submit()
    {
        Submitting = true;
        Thread.Sleep(1000);

        SubmitSucceeded = true;
        Submitting = false;
        Close();
    }

    [RelayCommand]
    public void Cancel()
    {
        SubmitSucceeded = false;

        Close();
    }
}