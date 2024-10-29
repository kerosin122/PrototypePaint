using System;
using System.Collections;
using UnityEngine;
public static class TimeCounting
{
    public static Action<bool> TimeIsUp;
    public static IEnumerator TimerCounting(float delay)
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

}
