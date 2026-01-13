using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace ExpenseTracker.ValueConverters;

public class AmountToBoolConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var amount = values.ElementAtOrDefault(0) as double?;
        var isShortcut = values.ElementAtOrDefault(1) is true;

        return !isShortcut || amount is null;
    }
}