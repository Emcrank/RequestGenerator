using System.Globalization;

namespace RequestGenerator.WPFApp.Converters;

public class RequestCardMaxFieldLengthConverter : BaseOneWayValueConverter
{
    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string text)
            return string.Empty;

        if (string.IsNullOrWhiteSpace(text))
            return text;

        const int MaxLength = 55;

        if (text.Length <= MaxLength)
            return text;

        int startIndex = text.Length - MaxLength;
        return $"...{text[startIndex..]}";
    }
}