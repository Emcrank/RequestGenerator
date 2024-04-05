using System.Security.Principal;
using System.Windows;

namespace RequestGenerator.WPFApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    /// <summary>Raises the <see cref="E:System.Windows.Application.Startup" /> event.</summary>
    /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        if (!IsAdministrator)
            MessageBox.Show("Some features of this application will not be available unless you run as Administrator.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

        base.OnStartup(e);
    }

    public static bool IsAdministrator =>
        new WindowsPrincipal(WindowsIdentity.GetCurrent())
            .IsInRole(WindowsBuiltInRole.Administrator);
}