using System;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.MainApp;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;
    
    [ObservableProperty]
    private PageViewModel _currentPage;

    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool ReportsPageIsActive => CurrentPage.PageName == ApplicationPageNames.Reports;

    /// <summary>
    /// Design-time Constructor
    /// </summary>
    public MainViewModel()
    {
        CurrentPage = new HomePageViewModel();
    }
    
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
        
        CurrentPage = _pageFactory.GetPageViewModel<HomePageViewModel>();
    }
    
    [RelayCommand]
    private void GoToHome() => CurrentPage = _pageFactory.GetPageViewModel<HomePageViewModel>();
    
    [RelayCommand]
    private void GoToReports() => CurrentPage = _pageFactory.GetPageViewModel<ReportsPageViewModel>();
}