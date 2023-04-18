# Basic Singleton

A common use case is the singleton pattern.
Therefore the <xref:Elke.Entities.Utility.BaseSingleton`1> is a <xref:UnityEngine.MonoBehaviour> that provides a very simple singleton implementation.

## Example

```cs
public class MySingleton : BaseSingleton<MySingleton>
{
    private void Awake()
    {
        AwakeInstance(this);
    }
}
```