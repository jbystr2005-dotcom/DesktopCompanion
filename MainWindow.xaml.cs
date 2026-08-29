using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopCompanion;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Rect workArea = SystemParameters.WorkArea;

        Left = workArea.Right - ActualWidth - 30;
        Top = workArea.Bottom - ActualHeight - 20;
    }

    private void Window_MouseLeftButtonDown(
        object sender,
        MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
            KeepInsideDesktop();
        }
    }

    private void KeepInsideDesktop()
    {
        Rect workArea = SystemParameters.WorkArea;

        Left = Math.Clamp(
            Left,
            workArea.Left,
            workArea.Right - ActualWidth);

        Top = Math.Clamp(
            Top,
            workArea.Top,
            workArea.Bottom - ActualHeight);
    }

    private async void SayHello_Click(
        object sender,
        RoutedEventArgs e)
    {
        SpeechText.Text = "Hello, Joshua!";
        SpeechBubble.Visibility = Visibility.Visible;

        await Task.Delay(2500);

        SpeechBubble.Visibility = Visibility.Collapsed;
    }

    private void Exit_Click(
        object sender,
        RoutedEventArgs e)
    {
        Close();
    }
}