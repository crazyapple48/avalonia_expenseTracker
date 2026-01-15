using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Data.Converters;
using ExpenseTracker.DataStorage.DataModels;

namespace ExpenseTracker.ValueConverters;

public class ListValuesToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null && value as ObservableCollection<ShortcutDataModel> !=
            new ObservableCollection<ShortcutDataModel>();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // ignored
        return null;
    }
}