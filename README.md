# Simple Coroutines
This wrapper for coroutines makes it easier to work with them.

## Setup
Add `SimpleCoroutines.cs` file to your project's assets. Now you are ready to go.

## Using
Type `this.` and now you can use Simple Coroutines in your MonoBehaviuor class. For example:

```csharp
using UnityEngine;

public class SimpleCoroutinesExample : MonoBehaviour
{
    void Start()
    {
        this.WaitForSeconds(0.5f, /*your action*/);
    }
}
```

Your action can be a delegate that has no parameters and does not return a value.

## Available Methods
| Method | Explanation |
| -------------------- | ---------------------------------------------------------- |
| `WaitForFrame(Action action)` | Waits until next frame |
| `WaitForFrames(int frames, Action action)` | Waits for `frames` frames |
| `WaitForFixedUpdate(Action action)` | Waits until next fixed frame rate update function |
| `WaitForEndOfFrame(Action action)` | Waits until the end of the frame after Unity has rendererd every Camera and GUI, just before displaying the frame on screen |
| `WaitForSeconds(float seconds, Action action)` | Waits for the given amount of `seconds` using scaled time |
| `WaitForCondition(Func<bool> condition, Action action)` | Waits until the `condition` is true |

## Example
Let's say you need a method that will disable an object after one second. Here's how you can do it with coroutines:

```csharp
using System.Collections;
using UnityEngine;

public class SimpleCoroutinesExample : MonoBehaviour
{
    private void SomeMethod()
    {
        StartCoroutine(EnableAfterSecond());
    }

    private IEnumerator EnableAfterSecond()
    {
        yield return new WaitForSeconds(1f);
        enabled = true;
    }
}
```

Here's how you can do it with Simple Coroutines:

```csharp
using UnityEngine;

public class SimpleCoroutinesExample : MonoBehaviour
{
    private void SomeMethod()
    {
        this.WaitForSeconds(1f, () => enabled = true);
    }
}
```

As you can see, by using Simple Coroutines you can make it much shorter and you don't have to create an individual method.
