using System;
using System.Timers;
using System.Windows.Input;
using ReactiveUI;

namespace flappy_bird.ViewModels;

public class PilarViewModel : ViewModelBase
{
    public int Width {get; private set;}
    public int Height {get; private set;}
    private int left;
    public int Left{
        get => this.left;
        set {
            this.RaiseAndSetIfChanged(ref this.left, value);
        }
    }
    
    private int top;
    public int Top{
        get => this.top;
        set {
            this.RaiseAndSetIfChanged(ref this.top, value);
        }
    }

    public PilarViewModel(int width, int height, int left, int top) {
        this.Width = width;
        this.Height = height;
        this.Left = left;
        this.Top = top;
    }

    public void MoveLeft(int step) {
        this.Left -= step;
    }

    public override string ToString() {
        return String.Format("{0} {1} {2} {3}", this.Width, this.Height, this.Left, this.Top);
    }
}
