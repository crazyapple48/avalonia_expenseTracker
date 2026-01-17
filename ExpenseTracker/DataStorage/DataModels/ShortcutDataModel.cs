using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.DataStorage.DataModels;

[Table("Shortcuts")]
public class ShortcutDataModel
{
    #region Properties

    public int Id { get; set; }

    [MaxLength(255)] public string Name { get; set; } = "";

    [MaxLength(255)] public string? Location { get; init; }

    public double? Amount { get; init; }

    [MaxLength(255)] public string? NickName { get; init; }

    [MaxLength(255)] public string? Reason { get; init; }

    [MaxLength(255)] public string? PaymentMethod { get; init; }

    #endregion
}