# ReadOnly-Attribute in Inspector

The <xref:Elke.Entities.Utility.Attributes.ReadOnlyAttribute> allows you to mark fields of a <xref:UnityEngine.MonoBehaviour> as read only.
Those fields will be displayed in the Unity Inspector but are not editable.

## Example

```cs
public class MyBehaviour : MonoBehaviour
{
    [ReadOnly]
    public float PI = Mathf.PI;
}
```