using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson6WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnDone_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private static Random random = new Random();

    void btnMy_MouseMove(object sender, MouseEventArgs e)
    {
        Button? btn = sender as Button;
        Size size = (btn?.Parent as Grid)!.RenderSize;
        Thickness margin = btn.Margin;
        margin.Left = random.NextDouble() * (size.Width - btn.ActualWidth);
        margin.Top = random.NextDouble() * (size.Height - btn.ActualHeight);
        btn.Margin = margin;
    }

}