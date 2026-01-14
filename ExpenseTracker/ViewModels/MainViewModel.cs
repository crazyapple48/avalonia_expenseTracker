using System;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Interfaces;
using ExpenseTracker.MainApp;
using ExpenseTracker.ViewModels.Base;
using ExpenseTracker.ViewModels.Dialogs;
using ExpenseTracker.ViewModels.Pages;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel(PageFactory pageFactory) : ViewModelBase, IDialogProvider
{
    private PageFactory? _pageFactory;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(HomePageIsActive), nameof(ReportsPageIsActive))]
    private PageViewModel _currentPage;

    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool ReportsPageIsActive => CurrentPage.PageName == ApplicationPageNames.Reports;

    [ObservableProperty] private DialogViewModel _dialog;

    /// <summary>
    /// Design-time Constructor
    /// </summary>
    public MainViewModel() : this(new PageFactory((_) => new ReportsPageViewModel()))
    {
        CurrentPage = new ReportsPageViewModel();
    }

    [RelayCommand]
    public void Initialize()
    {
        _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
        CurrentPage = _pageFactory.GetPageViewModel<HomePageViewModel>();
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage = _pageFactory.GetPageViewModel<HomePageViewModel>();

    [RelayCommand]
    private void GoToReports() => CurrentPage = _pageFactory.GetPageViewModel<ReportsPageViewModel>();
}