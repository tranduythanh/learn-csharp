using System;
using ReactiveUI;

namespace flappy_bird.ViewModels;

public class BirdViewModel : ViewModelBase
{
    private double acceleration = 3;
    public int Width {get; private set;}
    public int Height {get; private set;}
    public double SpeedY {get; private set;} = 0;
    private int left;
    public int Left{
        get => this.left;
        set => this.RaiseAndSetIfChanged(ref this.left, value);
    }
    
    private double top;
    public double Top{
        get => this.top;
        set => this.RaiseAndSetIfChanged(ref this.top, value);
    }

    public BirdViewModel( int width, int height, int left, int top) {
        this.Width = width;
        this.Height = height;
        this.Left = left;
        this.Top = top;
    }

    public void Jumb(double speed) {
        this.SpeedY += speed;
    }

    public void Fly(int deltaTimeMilliSec) {
        double deltaY = this.SpeedY * Convert.ToDouble(deltaTimeMilliSec)/1000.0;
        this.Top -= deltaY;
        Console.WriteLine(this.Top);
        this.SpeedY -= acceleration;
        Console.WriteLine(this.SpeedY);
    }

    public override string ToString() {
        return String.Format("{0} {1}", this.Top, this.SpeedY);
    }
}
