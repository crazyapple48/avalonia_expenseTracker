using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseTracker.ViewModels;

public partial class SelectedShortcutViewModel
    : ViewModelBase
{
    #region Members

    #endregion

    #region Properties

    public string Name { get; set; } = "";
    public string? Location { get; init; }
    public double? Amount { get; init; }
    public string? NickName { get; init; }
    public string? Reason { get; init; }
    public string? PaymentMethod { get; init; }

    #endregion
}