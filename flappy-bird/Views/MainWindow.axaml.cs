using Avalonia.Controls;
using Avalonia.Input;
using flappy_bird.ViewModels;

namespace flappy_bird.Views;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
    }

    protected override void OnKeyDown(KeyEventArgs e) {
        base.OnKeyDown(e);
        new MainWindowViewModel().HandleKeyDown(e);
    }
}