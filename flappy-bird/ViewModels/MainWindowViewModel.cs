using System;
using System.Collections.Generic;
using System.Timers;
using Avalonia.Input;
using ReactiveUI;
using Avalonia.Collections;
using System.Reactive;

namespace flappy_bird.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    const int pilarWidth = 100;
    const int birdSize = 50;
    const int intervalMilliSec = 5;
    const int ScreenWidth = 720;
    const int ScreenHeight = 720;
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

    private AvaloniaList<PilarViewModel> _pilars;
    public AvaloniaList<PilarViewModel> Pilars {
        get => this._pilars;
        set {
            this.RaiseAndSetIfChanged(ref this._pilars, value);
        } 
    }

    private BirdViewModel _bird; // new(ScreenHeight, birdSize, birdSize, ScreenWidth/4, ScreenHeight/2);
    public BirdViewModel Bird {
        get => this._bird;
        set {
            this.RaiseAndSetIfChanged(ref this._bird, value);
        } 
    }

    public MainWindowViewModel() {
        // setup pilars
        this.SetupPilars();
        
        // setup the angry bird =)))
        this.SetupBird();

        // setup timer
        gameTimer.AutoReset = true;
        gameTimer.Elapsed += this.OnTimedEvent;
        gameTimer.Start();

    }

    public ReactiveCommand<Unit, Unit> BirdJumb { get; }

    public void BirdJumbHandler() {
        this.Bird.Jumb(1000);
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)  {
        this.GameTimerValue = e.SignalTime.ToString();
        
        // move all pilars
        foreach(var p in this.Pilars) {
            p.MoveLeft(1);
        }
        
        this.CheckToRotatePilars();
        
        this.Bird.Fly(intervalMilliSec);

        this.Debug();
    }

    private int RandomPilarPadding() {
        return this.rnd.Next(this.pillarPaddingRange[0], this.pillarPaddingRange[1]);
    }

    private int RandomPilarTop() {
        int ret = this.rnd.Next(ScreenHeight/3, ScreenHeight*2/3);
        return Convert.ToInt32(Math.Pow(-1, this.rnd.Next(0, 2))) * ret;
    }

    private void SetupPilars() {
        // init 4 pilars with default value
        AvaloniaList<PilarViewModel> ret = new(){
            new(pilarWidth, ScreenHeight, 1000, 0),
            new(pilarWidth, ScreenHeight, 1000, 0),
            new(pilarWidth, ScreenHeight, 1000, 0),
            new(pilarWidth, ScreenHeight, 1000, 0),
        };
        // setup pilar padding
        for (int i = 1; i<ret.Count; i++) {
            ret[i].Left = ret[i-1].Left + this.RandomPilarPadding();
        }
        // setup pilar top
        foreach(var p in ret) {
            p.Top = this.RandomPilarTop();
        }
        this.Pilars = ret;
    }

    private void CheckToRotatePilars() {
        if (this.Pilars[0].Left >= -pilarWidth) {
            return;
        }
        int lastIdx = this.Pilars.Count-1;
        this.Pilars.RemoveAt(0);
        this.Pilars.Add(new(pilarWidth, ScreenHeight, 1000, 0));
        this.Pilars[lastIdx].Left = this.Pilars[lastIdx-1].Left+this.RandomPilarPadding();
        this.Pilars[lastIdx].Top = this.RandomPilarTop();
    }

    private void SetupBird() {
        this.Bird  = new BirdViewModel(ScreenHeight, birdSize, birdSize, ScreenWidth/4, ScreenHeight/2);
    }

    private void Debug() {
        Console.WriteLine(this.Bird);
        // foreach(var p in this.Pilars) {
        //     Console.WriteLine(p);
        // }
    }

    public void HandleKeyDown(KeyEventArgs e) {
        if (e.Key != Key.Space) {
            return;
        }
        this.Bird.Jumb(100);
    }

    // check collision
}
