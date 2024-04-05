using System.Windows;
using RequestGenerator.Logic.Requests;

namespace RequestGenerator.WPFApp.Views;

/// <summary>
/// Interaction logic for FakeFileRequestEditWindow.xaml
/// </summary>
public partial class FsUtilFileRequestEditWindow : EditWindow<FsUtilFileRequest>
{
    public FsUtilFileRequestEditWindow()
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