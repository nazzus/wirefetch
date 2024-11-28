using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;

namespace Wirefetch;

public partial class MainWindow : Window
{
    private readonly HttpRequestManager _requestManager;

    public MainWindow()
    {
        Title = "Wirefetch";
        Width = 1280;
        Height = 720;
        Background = new SolidColorBrush(
            (Color)ColorConverter.ConvertFromString("#0D0C1D")
        );
        Style = new Style()
        {
            Setters = {
                new Setter(ForegroundProperty, Brushes.White)
            }
        };
        WindowChrome.SetWindowChrome(this, new WindowChrome()
        {
            ResizeBorderThickness = new Thickness(5),
            CornerRadius = new CornerRadius(0),
            CaptionHeight = 0
        });

        _requestManager = new();

        Loaded += new RoutedEventHandler(LoadUI);
    }

    private void LoadUI(object sender, RoutedEventArgs args)
    {
        Border chromeBorder = new()
        {
            Padding = new Thickness(2, 0, 2, 0)
        };

        StackPanel chrome = new()
        {
            Width = Width, // window width
            Height = 30,
            Background = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString("#161B33")
            ),
            VerticalAlignment = VerticalAlignment.Top
        };

        chrome.MouseDown += (sender, e) =>
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        };

        TextBlock appTitle = new()
        {
            Text = "Wirefetch",
            HorizontalAlignment = HorizontalAlignment.Left
        };

        chrome.Children.Add(appTitle);

        chromeBorder.Child = chrome;
        AddChild(chromeBorder);
    }

    [STAThread]
    public static void Main()
    {
        Application app = new();

        app.Run(new MainWindow());
    }
}