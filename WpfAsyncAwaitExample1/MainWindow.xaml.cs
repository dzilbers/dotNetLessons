using System.Windows;
using System.Windows.Controls;

namespace WpfAsyncAwaitExample1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static readonly DependencyProperty StatusTextProperty =
        DependencyProperty.Register(nameof(StatusText), typeof(string), typeof(MainWindow),
            new PropertyMetadata("מוכן לפעולה"));
    public string StatusText
    {
        get => (string)GetValue(StatusTextProperty);
        set => SetValue(StatusTextProperty, value);
    }
    public static readonly DependencyProperty IsLoadingProperty =
        DependencyProperty.Register(nameof(IsLoading), typeof(bool), typeof(MainWindow),
            new PropertyMetadata(false));
    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public MainWindow() => InitializeComponent();

    private static Random random = new();

    private async void startButton_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = (sender as Button)!;
        if (clickedButton is null) return;

        // While still in UI thread, update the UI to show loading state
        StatusText = "...מתחיל בעבודה כבדה, אנא המתן";
        IsLoading = true; // Initiate progress bar animation
        clickedButton.IsEnabled = false; // disable the clicked button

        try
        {
            // Transfer to background (working) thread (from a Thread Pool) by using await
            // thus freeing up the UI thread to remain responsive
            // The current "Synchronization Context" is automatically captured
            string result = await Task.Run(() =>
            {
                Thread.Sleep(3000); // Simulate heavy work (e.g., I/O, CPU-bound, etc.) for 3 seconds
                return random.NextDouble() < 0.5 ? "העבודה הסתיימה בהצלחה! הנתונים עובדו."
                                                 : throw new Exception("אופס!!!");
            });

            // Due to the captured Synchronization Context, we are back on the UI thread here
            // so it's safe to update UI properties
            StatusText = result;
        }
        catch (Exception ex) // handle error safely, in UI thread
        {
            StatusText = $"אירעה שגיאה: {ex.Message}";
        }
        finally // always runs, regardless of success or exception
        { // stage 4 cleanup (always in UI thread)
            IsLoading = false; // turn off progress bar animation
            clickedButton.IsEnabled = true; // re-enable the clicked button
        }
    }
}