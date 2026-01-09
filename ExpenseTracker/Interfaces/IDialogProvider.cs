using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Interfaces;

public interface IDialogProvider
{
    DialogViewModel Dialog { get; set; }
}