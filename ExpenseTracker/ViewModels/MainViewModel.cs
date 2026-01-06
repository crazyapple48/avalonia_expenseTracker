using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;

    private readonly HomePageViewModel _homePage = new();
    private readonly ReportsPageViewModel _reportsPage = new();
    
    public MainViewModel() => CurrentPage = _homePage;
}