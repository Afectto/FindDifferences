using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerMonoBehaviour : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    
    private Timer _timer;
    
    private const int TIMER_LIMIT = 2;
    
    public static Action OnTimerIsOver;

    void Start()
    {
        _timer = new Timer();
        OnStartTimer();
        CounterDifferences.OnAllDifferencesFind += OnAllDifferencesFind;
        LevelChanger.OnStartNewLvl += OnStartTimer;
    }

    void Update()
    {
        _timer.Update();
        _timerText.text = _timer.GetTimeFormatted();
        if (_timer.GetMinutes() >= TIMER_LIMIT)
        {
            _timer.StopTimer();
            OnTimerIsOver.Invoke();
        }
    }

    private void OnStartTimer()
    {
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
    }
}
