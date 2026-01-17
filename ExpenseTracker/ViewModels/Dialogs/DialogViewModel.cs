using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.ViewModels.Base;

namespace ExpenseTracker.ViewModels.Dialogs;

public partial class DialogViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isDialogOpen;

    protected TaskCompletionSource closeTask = new TaskCompletionSource();

    public async Task<bool> WaitAsync()
    {
        await closeTask.Task;

        return closeTask.Task.IsCompletedSuccessfully;
    }

    public void Show()
    {
        if (closeTask.Task.IsCompleted) closeTask = new TaskCompletionSource();

        IsDialogOpen = true;
    }

    public bool Close()
    {
        IsDialogOpen = false;

        return closeTask.TrySetResult();
    }
}