namespace KimApp.ViewModels;

using System;
using System.Timers;
using Microsoft.Maui.Controls;

public class ChessTimerViewModel : BindableObject
{
    private Timer _timer;
    private TimeSpan _playerOneTime;
    private TimeSpan _playerTwoTime;
    private bool _isPlayerOneActive;
    private bool _isPlayerTwoActive;

    public ChessTimerViewModel()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += (sender, e) =>
        {
            if (_isPlayerOneActive) 
            {
                _playerOneTime = _playerOneTime.Add(TimeSpan.FromSeconds(-1));
                OnPropertyChanged(nameof(PlayerOneTime));
            }
            if (_isPlayerTwoActive) 
            {
                _playerTwoTime = _playerTwoTime.Add(TimeSpan.FromSeconds(-1));
                OnPropertyChanged(nameof(PlayerTwoTime));
            }
        };
        _timer.AutoReset = true;
        ResetTimers();
    }
    
    private void UpdateTimer()
    {
        if (_isPlayerOneActive || _isPlayerTwoActive)
            _timer.Start();
        else
            _timer.Stop();
    }

    public string PlayerOneTime => _playerOneTime.ToString(@"mm\:ss");
    public string PlayerTwoTime => _playerTwoTime.ToString(@"mm\:ss");

    public Command StartPausePlayerOneCommand => new Command(() => {
        _isPlayerOneActive = !_isPlayerOneActive;
        UpdateTimer();
    });
    public Command StartPausePlayerTwoCommand => new Command(() => {
        _isPlayerTwoActive = !_isPlayerTwoActive;
        UpdateTimer();
    });
    public Command ResetTimersCommand => new Command(ResetTimers);

    private void ResetTimers()
    {
        _playerOneTime = TimeSpan.FromMinutes(10);
        _playerTwoTime = TimeSpan.FromMinutes(10);
        OnPropertyChanged(nameof(PlayerOneTime));
        OnPropertyChanged(nameof(PlayerTwoTime));
        _isPlayerOneActive = false;
        _isPlayerTwoActive = false;
        UpdateTimer(); 
    }
}
