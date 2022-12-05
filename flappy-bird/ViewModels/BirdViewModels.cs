using System;
using ReactiveUI;

namespace flappy_bird.ViewModels;

public class BirdViewModel : ViewModelBase
{
    private double acceleration = 3;
    public int SkyHeight = 0;
    public int Width {get; private set;}
    public int Height {get; private set;}
    public double SpeedY {get; private set;}
    private int _left;
    public int Left{
        get => this._left;
        set => this.RaiseAndSetIfChanged(ref this._left, value);
    }
    
    private double _top;
    public double Top{
        get => this._top;
        set => this.RaiseAndSetIfChanged(ref this._top, value);
    }

    public BirdViewModel(int skyHeight, int width, int height, int left, int top) {
        this.Width = width;
        this.Height = height;
        this.Left = left;
        this.Top = top;
        this.SkyHeight = skyHeight;
    }

    public void Jump(double speed) {
        lock(this) {
            this.SpeedY += speed;
        }
    }

    public void Fly(int deltaTimeMilliSec) {
        lock (this) {
            double deltaY = this.SpeedY * Convert.ToDouble(deltaTimeMilliSec)/1000.0;
            this.Top -= deltaY;
            if (this.Top > this.SkyHeight - this.Height) {
                this.Top = this.SkyHeight - this.Height;
                this.SpeedY = 700;
            } else {
                this.SpeedY -= acceleration;
            }
        }
    }

    public override string ToString() {
        lock(this) {
            return String.Format("{1} {2}", this.Top.ToString("N2"), this.SpeedY.ToString("N2"));
        }
    }
}
