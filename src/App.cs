using System.Windows;
using Wpf.Ui.Controls;

namespace Wirefetch;

public partial class MainWindow : Window
{
    private readonly HttpRequestManager _requestManager;

    public MainWindow()
    {
        Title = "Wirefetch";
        Width = 1280;
        Height = 720;

        _requestManager = new();

        Loaded += new RoutedEventHandler(LoadUI);
    }

    private void LoadUI(object sender, RoutedEventArgs args)
    {
        TextBlock textBlock = new()
        {
            Text = "Hello world!",
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };

        AddChild(textBlock);
    }

    [STAThread]
    public static void Main()
    {
        Application app = new();

        app.Run(new MainWindow());
    }
}