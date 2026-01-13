using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseTracker.ViewModels;

public partial class SelectedShortcutViewModel : ViewModelBase
{
    #region Members

    [ObservableProperty] private string _name = "Gas";
    [ObservableProperty] private string? _location;
    [ObservableProperty] private double? _amount;
    [ObservableProperty] private string? _nickName;
    [ObservableProperty] private string? _reason;
    [ObservableProperty] private string? _paymentMethod;

    #endregion
}