using ExpenseTracker.ViewModels;
using ExpenseTracker.ViewModels.Dialogs;

namespace ExpenseTracker.Interfaces;

public interface IDialogProvider
{
    DialogViewModel Dialog { get; set; }
}