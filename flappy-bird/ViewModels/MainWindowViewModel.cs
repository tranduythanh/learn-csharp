using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Input;
using ReactiveUI;
using Avalonia.Collections;

namespace flappy_bird.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    const int pilarWidth = 100;
    const int screenHeight = 0;
    const int intervalMilliSec = 5;
    private int screenWidth = 0;
    private List<int> pillarPaddingRange = new(){400,600}; 
    private Random rnd = new Random();


    private static Timer gameTimer = new Timer(intervalMilliSec); // milliseconds
    public string Greeting => "Trần Duy Thanh - Flappy Bird";

    private string gameTimerValue; 
    public string GameTimerValue{
        get => this.gameTimerValue;
        set {
            this.RaiseAndSetIfChanged(ref this.gameTimerValue, value);
        }
    }

    private AvaloniaList<PilarViewModel> pilars;
    public AvaloniaList<PilarViewModel> Pilars {
        get => pilars;
        set {
            this.RaiseAndSetIfChanged(ref this.pilars, value);
            Console.WriteLine(pilars[0]);
        } 
    }

    public MainWindowViewModel() {
        // setup timer
        gameTimer.AutoReset = true;
        gameTimer.Elapsed += this.OnTimedEvent;
        gameTimer.Start();

        // setup pilars
        this.SetupPilars();
        

        // setup the angry bird =)))
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)  {
        Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        this.GameTimerValue = e.SignalTime.ToString();
        
        // move all pilars
        AvaloniaList<PilarViewModel> ret = new();
        for(int i = 0; i < this.Pilars.Count; i++) {
            this.Pilars[i].MoveLeft(1);
            ret.Add(this.Pilars[i]);
        }
        this.Pilars = ret;
        this.CheckToRotatePilars();

        // move the birds
    }

    private int RandomPilarPadding() {
        return this.rnd.Next(this.pillarPaddingRange[0], this.pillarPaddingRange[1]);
    }

    private void SetupPilars() {
        AvaloniaList<PilarViewModel> ret = new(){
            new(pilarWidth, 60, 1000, 0),
            new(pilarWidth, 60, 1000, 0),
            new(pilarWidth, 60, 1000, 0),
            new(pilarWidth, 60, 1000, 0),
        };
        for (int i = 1; i<ret.Count; i++) {
            ret[i].Left = ret[i-1].Left + this.RandomPilarPadding();
        }
        this.Pilars = ret;
    }

    private void CheckToRotatePilars() {
        if (this.Pilars[0].Left >= -pilarWidth) {
            return;
        }
        int lastIdx = this.Pilars.Count -1;
        this.Pilars.Move(0, lastIdx);
        this.Pilars[lastIdx].Left = this.Pilars[lastIdx-1].Left+this.RandomPilarPadding();
    }

    // get screen size

    // handle key down

    // check collision
}
