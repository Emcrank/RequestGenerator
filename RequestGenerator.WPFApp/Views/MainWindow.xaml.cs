using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using RequestGenerator.WPFApp.ViewModels.Pages;

namespace RequestGenerator.WPFApp.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(this);
    }

    private void RPMTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;

        string TextStoreGet() => (string)textBox.Tag;
        void TextStoreSet() => textBox.Tag = textBox.Text;

        if (textBox.Text == string.Empty || textBox.Text == "*" || int.TryParse(textBox.Text, NumberStyles.None, CultureInfo.InvariantCulture, out _))
        {
            TextStoreSet();
        }
        else
        {
            textBox.Text = TextStoreGet();
            textBox.CaretIndex = textBox.Text.Length;
        }
    }

    //private void ListView_OnSourceUpdated(object sender, DataTransferEventArgs e)
    //{
    //    var listView = (ListView)sender;

    //    ((INotifyCollectionChanged)listView.ItemsSource).CollectionChanged +=
    //        (s, args) =>
    //        {
    //            if (args.Action == NotifyCollectionChangedAction.Add)
    //            {
    //                listView.ScrollIntoView(listView.Items[^1]);
    //            }
    //        };
    //}
}