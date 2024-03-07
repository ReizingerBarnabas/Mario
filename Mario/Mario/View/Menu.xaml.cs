using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
namespace Mario.View;

public partial class Menu : UserControl
{
    // Esemény definíciója a UserControl bezárásához
    public event EventHandler CloseRequested;

    public Menu()
    {
        InitializeComponent();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void btnBackToGame_Click(object sender, RoutedEventArgs e)
    {
        // UserControl bezárásának kérése
        CloseRequested?.Invoke(this, EventArgs.Empty);
    }
}