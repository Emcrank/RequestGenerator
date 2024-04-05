using System.Windows;
using System.Windows.Controls;
using RequestGenerator.WPFApp.Services;

namespace RequestGenerator.WPFApp.Views;

/// <summary>
/// Interaction logic for RequestSelectionWindow.xaml
/// </summary>
public partial class RequestSelectionWindow : Window
{
    public RequestSelectionWindow()
    {
        InitializeComponent();
    }

    public Window? ChosenWindow { get; private set; }

    private void WindowSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;

        if (comboBox.SelectedIndex == -1)
            return;

        ChosenWindow = RequestEditWindowFactory.CreateWindow((string)comboBox.SelectedItem);

        DialogResult = true;
        Close();
    }

    private void WindowSelector_OnLoaded(object sender, RoutedEventArgs e)
    {
        PopulateItems((ComboBox)sender);
    }

    private void PopulateItems(ComboBox control)
    {
        control.ItemsSource = RequestEditWindowFactory.WindowNames;
    }

    private void CancelButton_OnClicked(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}