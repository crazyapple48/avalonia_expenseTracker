namespace ExpenseTracker.Models;

public class ShortcutModel
{
    #region Properties

    public string Name { get; set; } = "";
    public string? Location { get; init; }
    public double? Amount { get; init; }
    public string? NickName { get; init; }
    public string? Reason { get; init; }
    public string? PaymentMethod { get; init; }

    #endregion
}