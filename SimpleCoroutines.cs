using System;
using System.Collections;
using UnityEngine;

public static class SimpleCoroutines
{
    public static Coroutine WaitForFrame(this MonoBehaviour behaviour, Action action)
    {
        return behaviour?.StartCoroutine(WaitForFrame(action));
    }

    private static IEnumerator WaitForFrame(Action action)
    {
        yield return null;
        action?.Invoke();
    }

    public static Coroutine WaitForFrames(this MonoBehaviour behaviour, int frames,
        Action action)
    {
        return behaviour?.StartCoroutine(WaitForFrames(frames, action));
    }

    private static IEnumerator WaitForFrames(int frames, Action action)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }

        action?.Invoke();
    }

    public static Coroutine WaitForFixedUpdate(this MonoBehaviour behaviour,
        Action action)
    {
        return behaviour?.StartCoroutine(WaitForFixedUpdate(action));
    }

    private static IEnumerator WaitForFixedUpdate(Action action)
    {
        yield return new WaitForFixedUpdate();
        action?.Invoke();
    }

    public static Coroutine WaitForEndOfFrame(this MonoBehaviour behaviour,
        Action action)
    {
        return behaviour?.StartCoroutine(WaitForEndOfFrame(action));
    }

    private static IEnumerator WaitForEndOfFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action?.Invoke();
    }

    public static Coroutine WaitForSeconds(this MonoBehaviour behaviour,
        float seconds, Action action)
    {
        return behaviour?.StartCoroutine(WaitForSeconds(seconds, action));
    }

    public static Coroutine WaitForSeconds(this MonoBehaviour behaviour,
        WaitForSeconds seconds, Action action)
    {
        return behaviour?.StartCoroutine(WaitForSeconds(seconds, action));
    }

    private static IEnumerator WaitForSeconds(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

    private static IEnumerator WaitForSeconds(WaitForSeconds seconds, Action action)
    {
        yield return seconds;
        action?.Invoke();
    }

    public static Coroutine WaitForCondition(this MonoBehaviour behaviour,
        Func<bool> condition, Action action)
    {
        return behaviour?.StartCoroutine(WaitForCondition(condition, action));
    }

    private static IEnumerator WaitForCondition(Func<bool> condition, Action action)
    {
        while (!condition())
        {
            yield return null;
        }

        action?.Invoke();
    }

    public static Coroutine WaitForYieldInstruction(this MonoBehaviour behaviour,
        YieldInstruction instruction, Action action)
    {
        return behaviour?.StartCoroutine(
            WaitForYieldInstruction(instruction, action));
    }

    private static IEnumerator WaitForYieldInstruction(YieldInstruction instruction,
        Action action)
    {
        yield return instruction;
        action?.Invoke();
    }
}
