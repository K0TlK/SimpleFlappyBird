using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : Singleton<GameTimer>
{
    private bool timerIsActive = false;
    private float time = 0;

    public float Time => time;
    public int TimeInt => Mathf.FloorToInt(time);
    public event UnityAction Restart;
    public event UnityAction Stop;

    public void StartTimer()
    {
        timerIsActive = true;
        time = 0;
        Restart.Invoke();
    }

    public void StopTimer()
    {
        timerIsActive = false;
        Stop.Invoke();
    }

    private void Update()
    {
        if (!timerIsActive)
        {
            return;
        }

        time += UnityEngine.Time.deltaTime;
    }
}
