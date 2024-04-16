using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace RequestGenerator.WPFApp.MarkupExtensions;

public class NameOfExtension : MarkupExtension
{
    private readonly PropertyPath propertyPath;

    public NameOfExtension(Binding binding)
    {
        ArgumentNullException.ThrowIfNull(binding);

        propertyPath = binding.Path;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        int indexOfLastVariableName = propertyPath.Path.LastIndexOf('.');
        return propertyPath.Path.Substring(indexOfLastVariableName + 1);
    }
}