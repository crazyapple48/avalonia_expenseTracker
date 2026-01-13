using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Avalonia.Data.Converters;

namespace ExpenseTracker.ValueConverters;

public class ShortcutValuesToBoolConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var text = values.ElementAtOrDefault(0) as string;
        var isShortcut = values.ElementAtOrDefault(1) is true;

        if (isShortcut && text != null || text is null)
        {
            return text is "" or null;
        }

        return true;
    }
}