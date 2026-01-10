using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Views;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
    }

    // private async Task Shortcut_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    // {
    //     if (sender is ListBox
    //         {
    //             DataContext: HomePageViewModel viewModel, SelectedItem: SelectedShortcutViewModel shortcut
    //         })
    //     {
    //         await viewModel.CreateExpenseAsync(shortcut);
    //     }
    // }
}