using System;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.DataStorage;
using ExpenseTracker.Interfaces;
using ExpenseTracker.MainApp;
using ExpenseTracker.ViewModels.Base;
using ExpenseTracker.ViewModels.Dialogs;
using ExpenseTracker.ViewModels.Pages;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel : ViewModelBase, IDialogProvider
{
    private readonly PageFactory? _pageFactory;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(HomePageIsActive), nameof(ReportsPageIsActive))]
    private PageViewModel? _currentPage;

    public bool HomePageIsActive => CurrentPage?.PageName == ApplicationPageNames.Home;
    public bool ReportsPageIsActive => CurrentPage?.PageName == ApplicationPageNames.Reports;

    [ObservableProperty] private DialogViewModel? _dialog;

    #region Constructors

    public MainViewModel(PageFactory pageFactory, DatabaseFactory factory)
    {
        _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
        var dbService = factory.GetDatabaseService();
        dbService.ApplyMigrations();
    }

    #endregion

    [RelayCommand]
    private void Initialize()
    {
        CurrentPage = _pageFactory?.GetPageViewModel<HomePageViewModel>() ?? throw new InvalidOperationException();
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage =
        _pageFactory?.GetPageViewModel<HomePageViewModel>() ?? throw new InvalidOperationException();

    [RelayCommand]
    private void GoToReports() => CurrentPage =
        _pageFactory?.GetPageViewModel<ReportsPageViewModel>() ?? throw new InvalidOperationException();
}