using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RequestGenerator.WPFApp.UserControls;

/// <summary>
/// Interaction logic for RequestCollectionViewControl.xaml
/// </summary>
public partial class RequestCollectionViewControl : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        nameof(ItemsSource),
        typeof(IEnumerable),
        typeof(RequestCollectionViewControl));

    public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(
        nameof(AddCommand),
        typeof(ICommand),
        typeof(RequestCollectionViewControl));

    public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(
        nameof(EditCommand),
        typeof(ICommand),
        typeof(RequestCollectionViewControl));

    public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
        nameof(DeleteCommand),
        typeof(ICommand),
        typeof(RequestCollectionViewControl));

    public RequestCollectionViewControl()
    {
        InitializeComponent();
    }

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public ICommand EditCommand
    {
        get => (ICommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    private void AddItem()
    {
        AddCommand.Execute(null);
    }

    private void DeleteSelectedItem()
    {
        DeleteCommand.Execute(ListView.SelectedItem);
    }

    private void EditSelectedItem()
    {
        EditCommand.Execute(ListView.SelectedItem);
    }

    private void ListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        EditSelectedItem();
    }

    private void ListViewMenuItemAdd_OnClick(object sender, RoutedEventArgs e)
    {
        AddItem();
    }

    private void ListViewMenuItemDelete_OnClick(object sender, RoutedEventArgs e)
    {
        DeleteSelectedItem();
    }

    private void ListViewMenuItemEdit_OnClick(object sender, RoutedEventArgs e)
    {
        EditSelectedItem();
    }
}