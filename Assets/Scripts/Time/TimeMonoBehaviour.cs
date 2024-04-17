using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerMonoBehaviour : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    
    private Timer _timer;
    
    private const int TIMER_MIN_LIMIT = 2;
    private int _currentLevelTimerLimit;
    
    public static Action OnTimerIsOver;

    void Start()
    {
        _timer = new Timer();
        _currentLevelTimerLimit = TIMER_MIN_LIMIT * 60;
        OnStartTimer();
        CounterDifferences.OnAllDifferencesFind += OnAllDifferencesFind;
        AppadealManager.OnRewardedVideoFinishedAction += OnRewardedVideoFinished;
        IAPCore.OnAddTimerLimit += OnAddTimerLimit;
    }

    private void OnAddTimerLimit(int value)
    {
        _currentLevelTimerLimit += value;
    }

    void Update()
    {
        _timer.Update();
        _timerText.text = _timer.GetTimeFormatted();
        if (_timer.GetMinutes()*60 + _timer.GetSeconds() >= _currentLevelTimerLimit)
        {
            _timer.StopTimer();
            OnTimerIsOver.Invoke();
        }
    }

    private void OnRewardedVideoFinished()
    {
        OnStartTimer();
    }

    private void OnStartTimer()
    {
        _currentLevelTimerLimit = TIMER_MIN_LIMIT * 60;
        _timer.Reset();
        _timer.Start();
    }

    private void OnAllDifferencesFind()
    {
        _timer.StopTimer();
    }

    private void OnDestroy()
    {
        CounterDifferences.OnAllDifferencesFind -= OnAllDifferencesFind;
        AppadealManager.OnRewardedVideoFinishedAction -= OnRewardedVideoFinished;
    }
}
