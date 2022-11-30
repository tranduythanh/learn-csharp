using System;
using System.Timers;
using System.Windows.Input;
using ReactiveUI;

namespace flappy_bird.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private static Timer gameTimer = new Timer(5); // milliseconds
    public string Greeting => "Trần Duy Thanh - Flappy Bird";
    
    private string gameTimerValue = "123"; 
    public string GameTimerValue{
        get => this.gameTimerValue;
        set => this.RaiseAndSetIfChanged(ref this.gameTimerValue, value);
    }

    // Pilar
    private int pilarPosLeft = 1000;
    public int PilarPosLeft{
        get => this.pilarPosLeft;
        set => this.RaiseAndSetIfChanged(ref this.pilarPosLeft, value);
    }
    private int pilarPosTop = 60;
    public int PilarPosTop{
        get => this.pilarPosTop;
        set => this.RaiseAndSetIfChanged(ref this.pilarPosTop, value);
    }

    public MainWindowViewModel() {
        System.Console.WriteLine("Ahihi");
        gameTimer.AutoReset = true;
        gameTimer.Elapsed += this.OnTimedEvent;
        gameTimer.Start();
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)  {
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        this.GameTimerValue = e.SignalTime.ToString();
        this.PilarPosLeft -= 1;
    }
}
