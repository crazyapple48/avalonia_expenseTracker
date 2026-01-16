using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.ViewModels.Base;

namespace ExpenseTracker.ViewModels.Models;

public partial class ShortcutViewModel : ViewModelBase
{
    #region Properties

    [ObservableProperty] private string _id = "";

    [ObservableProperty] private string _name = "";

    [ObservableProperty] private string? _location;

    [ObservableProperty] private double? _amount;

    [ObservableProperty] private string? _nickName;

    [ObservableProperty] private string? _reason;

    [ObservableProperty] private string? _paymentMethod;

    #endregion
}