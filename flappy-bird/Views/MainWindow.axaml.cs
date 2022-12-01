using Avalonia.Controls;
using System;

namespace flappy_bird.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        Console.WriteLine(this.Height);
        InitializeComponent();
    }
}