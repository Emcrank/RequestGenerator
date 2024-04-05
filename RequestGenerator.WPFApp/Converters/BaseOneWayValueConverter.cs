using System.Globalization;
using System.Windows.Data;

namespace RequestGenerator.WPFApp.Converters;

/// <summary>
/// Inherit this for one-way converters to avoid unnecessary extra methods in each converter
/// </summary>
public abstract class BaseOneWayValueConverter : IValueConverter
{
    public abstract object Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException($"{GetType().Name} is a one-way converter");
}