using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DotNetTool.Pages;

public partial class TimestampView : UserControl
{
    public TimestampView()
    {
        InitializeComponent();
    }

    private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            textBox.LostFocus -= TextBox_LostFocus;
            textBox.LostFocus += TextBox_LostFocus;
        }
    }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox != null)
        {
            textBox.LostFocus -= TextBox_LostFocus;
            textBox.RaiseEvent(new RoutedEventArgs(TextBox.TextChangedEvent));
        }
    }
}