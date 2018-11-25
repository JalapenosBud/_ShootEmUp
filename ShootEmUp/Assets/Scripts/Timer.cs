using UnityEngine;
using System.Collections;

public class Timer {

    //tid tilbage på cooldown
    float timer;
    
    /// <summary>
    /// This property checks if the timer can start
    /// pre: timer must be at 0 seconds or below
    /// </summary>
    private bool CanTimerStart
    {
        get
        {
            return timer <= 0f;
        }
    }

    public void RunTimer()
    {
        if(CanTimerStart)
        {
            timer -= Time.deltaTime;
        }
    }
}
