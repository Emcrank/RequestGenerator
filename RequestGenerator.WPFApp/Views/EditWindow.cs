using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace RequestGenerator.WPFApp.Views;

public abstract class EditWindow<T> : Window where T : new()
{
    protected bool IsNewItem;

    protected EditWindow()
    {
        DataContext = new T();
        IsNewItem = true;
    }

    public new T DataContext
    {
        get => (T)base.DataContext;
        set
        {
            base.DataContext = value;
            IsNewItem = false;
        }
    }

    protected void CancelButton_OnClicked(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    protected void FilePathBrowseButtonToTextBox_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        string textBoxName = (string)button.Tag;
        var textBox = (TextBox?)FindName(textBoxName) ?? throw new InvalidOperationException($"Unable to find control named '{textBoxName}'.");

        var fileOpen = new OpenFileDialog { CheckFileExists = true, Title = "Choose file", ValidateNames = true, Filter = (string)textBox.Tag };

        if (fileOpen.ShowDialog(this) != true)
            return;

        textBox.Text = fileOpen.FileName;
        textBox.Focus();
    }

    protected void NumericTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (textBox.Text == string.Empty)
        {
            textBox.Text = "0";
            textBox.Focus();
        }
    }

    protected void NumericTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;

        string TextStoreGet() => (string)textBox.Tag;
        void TextStoreSet() => textBox.Tag = textBox.Text;

        if (textBox.Text == string.Empty || int.TryParse(textBox.Text, NumberStyles.None, CultureInfo.InvariantCulture, out _))
        {
            TextStoreSet();
            textBox.Focus();
        }
        else
        {
            textBox.Text = TextStoreGet();
            textBox.CaretIndex = textBox.Text.Length;
        }
    }

    protected void OKButton_OnClicked(object sender, RoutedEventArgs e)
    {
        if (PreOkValidation())
        {
            DialogResult = true;
            Close();
        }
    }

    protected abstract bool PreOkValidation();
}