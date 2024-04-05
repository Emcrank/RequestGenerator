using System.Windows;
using RequestGenerator.Logic.Requests;

namespace RequestGenerator.WPFApp.Views;

/// <summary>
/// Interaction logic for TemplatedFileRequestEditWindow.xaml
/// </summary>
public partial class TemplatedFileRequestEditWindow : EditWindow<TemplatedFileRequest>
{
    public TemplatedFileRequestEditWindow()
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
}