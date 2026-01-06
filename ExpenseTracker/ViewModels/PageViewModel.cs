using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageNames _pageName;
    
    protected PageViewModel(ApplicationPageNames pageName) => _pageName = pageName;
}