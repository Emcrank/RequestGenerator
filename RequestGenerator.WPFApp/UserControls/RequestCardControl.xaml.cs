using System.Windows;
using System.Windows.Controls;

namespace RequestGenerator.WPFApp.UserControls;

/// <summary>
/// Interaction logic for RequestCardControl.xaml
/// </summary>
public partial class RequestCardControl : UserControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row1NameProperty = DependencyProperty.Register(nameof(Row1Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row2NameProperty = DependencyProperty.Register(nameof(Row2Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row3NameProperty = DependencyProperty.Register(nameof(Row3Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row4NameProperty = DependencyProperty.Register(nameof(Row4Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row5NameProperty = DependencyProperty.Register(nameof(Row5Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row6NameProperty = DependencyProperty.Register(nameof(Row6Name), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row1ValueProperty = DependencyProperty.Register(nameof(Row1Value), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row2ValueProperty = DependencyProperty.Register(nameof(Row2Value), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row3ValueProperty = DependencyProperty.Register(nameof(Row3Value), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row4ValueProperty = DependencyProperty.Register(nameof(Row4Value), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row5ValueProperty = DependencyProperty.Register(nameof(Row5Value), typeof(string), typeof(RequestCardControl));

    public static readonly DependencyProperty Row6ValueProperty = DependencyProperty.Register(nameof(Row6Value), typeof(string), typeof(RequestCardControl));

    public RequestCardControl()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Row1Name
    {
        get => (string)GetValue(Row1NameProperty);
        set => SetValue(Row1NameProperty, value);
    }

    public string Row1Value
    {
        get => (string)GetValue(Row1ValueProperty);
        set => SetValue(Row1ValueProperty, value);
    }

    public string Row2Name
    {
        get => (string)GetValue(Row2NameProperty);
        set => SetValue(Row2NameProperty, value);
    }

    public string Row2Value
    {
        get => (string)GetValue(Row2ValueProperty);
        set => SetValue(Row2ValueProperty, value);
    }

    public string Row3Name
    {
        get => (string)GetValue(Row3NameProperty);
        set => SetValue(Row3NameProperty, value);
    }

    public string Row3Value
    {
        get => (string)GetValue(Row3ValueProperty);
        set => SetValue(Row3ValueProperty, value);
    }

    public string Row4Name
    {
        get => (string)GetValue(Row4NameProperty);
        set => SetValue(Row4NameProperty, value);
    }

    public string Row4Value
    {
        get => (string)GetValue(Row4ValueProperty);
        set => SetValue(Row4ValueProperty, value);
    }

    public string Row5Name
    {
        get => (string)GetValue(Row5NameProperty);
        set => SetValue(Row5NameProperty, value);
    }

    public string Row5Value
    {
        get => (string)GetValue(Row5ValueProperty);
        set => SetValue(Row5ValueProperty, value);
    }

    public string Row6Name
    {
        get => (string)GetValue(Row6NameProperty);
        set => SetValue(Row6NameProperty, value);
    }

    public string Row6Value
    {
        get => (string)GetValue(Row6ValueProperty);
        set => SetValue(Row6ValueProperty, value);
    }
}