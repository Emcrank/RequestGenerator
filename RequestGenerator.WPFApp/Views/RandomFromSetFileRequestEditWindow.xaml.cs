using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using RequestGenerator.Logic.Requests;

namespace RequestGenerator.WPFApp.Views;

/// <summary>
/// Interaction logic for TemplatedFileRequestEditWindow.xaml
/// </summary>
public partial class RandomFromSetFileRequestEditWindow : EditWindow<RandomFromSetFileRequest>
{
    public RandomFromSetFileRequestEditWindow()
    {
        InitializeComponent();
    }

    protected override bool PreOkValidation()
    {
        try
        {
            DataContext.PreGeneration();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    protected void MultiFilePathBrowseButtonToListBox_OnClicked(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        string listBoxName = (string)button.Tag;
        var listBox = (ListBox?)FindName(listBoxName) ?? throw new InvalidOperationException($"Unable to find control named '{listBoxName}'.");

        var fileOpen = new OpenFileDialog
        {
            CheckFileExists = true,
            Multiselect = true,
            Title = "Choose file",
            ValidateNames = true,
            Filter = (string)listBox.Tag
        };

        if (fileOpen.ShowDialog(this) != true)
            return;

        var list = ((IList) listBox.ItemsSource);

        foreach (string fileName in fileOpen.FileNames)
        {
            if (!list.Contains(fileName))
                list.Add(fileName);
        }
    }

}