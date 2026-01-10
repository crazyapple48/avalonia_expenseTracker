using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseTracker.ViewModels;

public partial class SelectedShortcutViewModel : ViewModelBase
{
    #region Members

    [ObservableProperty] private string _name = "Gas";
    [ObservableProperty] private string _location = "QT";
    [ObservableProperty] private double _amount = 3.75;
    [ObservableProperty] private string _nickName = "Disney";
    [ObservableProperty] private string _reason = "Me";
    [ObservableProperty] private string _paymentMethod = "Credit Card";

    #endregion
}