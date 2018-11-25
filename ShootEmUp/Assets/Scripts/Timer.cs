using UnityEngine;
using System.Collections;

public class Timer {

    //tid tilbage på cooldown
    float timer;
    
    /// <summary>
    /// This property checks if the timer can start
    /// pre: timer must be at 0 seconds or below
    /// </summary>
    public bool CanTimerStart
    {
        get
        {
            return timer <= 0f;
        }
    }




    //pre: timer (seconds) must be above 0
    //post: 
    /*public bool IsTimerRunning
    {
        get
        {
            return timer > 0;
        }
    }

    public void RunTimer()
    {
        if(IsTimerRunning)
        {
            timer -= Time.deltaTime;
        }
    }

    public void StartTimer(float totalTimeToRun)
    {
        timer = time;
    }*/
}
