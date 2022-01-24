using System;
using System.Collections;
using UnityEngine;

public static class SimpleCoroutines
{

    public static void WaitForFrame(this MonoBehaviour behaviour, Action action)
    {
        behaviour.StartCoroutine(WaitForFrame(action));
    }

    private static IEnumerator WaitForFrame(Action action)
    {
        yield return null;
        action();
    }

    public static void WaitForFrames(this MonoBehaviour behaviour, int frames, Action action)
    {
        behaviour.StartCoroutine(WaitForFrames(frames, action));
    }

    private static IEnumerator WaitForFrames(int frames, Action action)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }

        action();
    }

    public static void WaitForFixedUpdate(this MonoBehaviour behaviour, Action action)
    {
        behaviour.StartCoroutine(WaitForFixedUpdate(action));
    }

    private static IEnumerator WaitForFixedUpdate(Action action)
    {
        yield return new WaitForFixedUpdate();
        action();
    }

    public static void WaitForEndOfFrame(this MonoBehaviour behaviour, Action action)
    {
        behaviour.StartCoroutine(WaitForEndOfFrame(action));
    }

    private static IEnumerator WaitForEndOfFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action();
    }

    public static void WaitForSeconds(this MonoBehaviour behaviour, float seconds, Action action)
    {
        behaviour.StartCoroutine(WaitForSeconds(seconds, action));
    }

    private static IEnumerator WaitForSeconds(float seconds, Action action)
    {
        if (action == null)
        {
            yield break;
        }
        
        yield return new WaitForSeconds(seconds);
        action();
    }
    
    public static void WaitForCondition(this MonoBehaviour behaviour, Func<bool> condition, Action action)
    {
        behaviour.StartCoroutine(WaitForCondition(condition, action));
    }

    private static IEnumerator WaitForCondition(Func<bool> condition, Action action)
    {
        while (!condition())
        {
            yield return null;
        }

        action();
    }
}
