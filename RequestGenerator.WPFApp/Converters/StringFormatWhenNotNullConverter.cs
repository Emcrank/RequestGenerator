using System.Globalization;

namespace RequestGenerator.WPFApp.Converters;

public class StringFormatWhenNotNullConverter : BaseOneWayValueConverter
{
    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string text)
            return string.Empty;

        if (string.IsNullOrWhiteSpace(text))
            return text;

        if (parameter is not string format)
            throw new InvalidOperationException("Invalid format.");

        return string.Format(format, text);
    }
}