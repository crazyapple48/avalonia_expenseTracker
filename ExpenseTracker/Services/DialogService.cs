using System.Threading.Tasks;
using ExpenseTracker.Interfaces;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Services;

public class DialogService
{
    public async Task ShowDialog<THost, TDialogViewModel>(THost host, TDialogViewModel viewModel)
        where TDialogViewModel : DialogViewModel
        where THost : IDialogProvider
    {
        // Set Host dialog to provided one
        host.Dialog = viewModel;

        viewModel.Show();

        // Wait for the dialog to close
        await viewModel.WaitAsync();
    }
}