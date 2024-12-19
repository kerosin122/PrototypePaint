using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class TimeCounting
{
    public Action<bool> TimeIsUp;
    public IEnumerator TimerCounting(float delay)
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;
            TimeIsUp?.Invoke(false);
            if (timer >= delay)
            {
                TimeIsUp?.Invoke(true);
                yield break;
            }
            yield return null;
        }
    }

    // public IEnumerator TimerCounting(float delay)
    // {
    //     TimeIsUp?.Invoke(false);
    //     yield return new WaitForSeconds(delay);
    //     TimeIsUp?.Invoke(true);
    // }
}
