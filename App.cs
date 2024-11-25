using System.Diagnostics;
using System.Windows;

namespace Wirefetch;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Debug.WriteLine("Hello World!");
    }

    [STAThread]
    public static void Main()
    {
        Application app = new();

        app.Run(new MainWindow());
    }
}