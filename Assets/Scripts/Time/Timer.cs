using UnityEngine;

public class Timer
{
    private float startTime;
    private float currentTime;

    private bool isStop;

    public Timer()
    {
        Reset();
        isStop = false;
    }

    public void Start()
    {
        startTime = Time.time;
    }

    public void Update()
    {
        if (isStop)
        {
            startTime = Time.time - currentTime;
        }
        else
        {
            currentTime = Time.time - startTime;
        }
    }

    public void Reset()
    {
        ContinueTimer();
        startTime = Time.time;
        currentTime = 0f;
    }
    
    public int GetMinutes()
    {
        return Mathf.FloorToInt(currentTime / 60);
    }

    public int GetSeconds()
    {
        return Mathf.FloorToInt(currentTime % 60);
    }

    public void StopTimer()
    {
        isStop = true;
    }

    public void ContinueTimer()
    {
        isStop = false;
    }
    
    public string GetTimeFormatted()
    {
        return string.Format("{0:D2}:{1:D2}", GetMinutes(), GetSeconds());
    }
}