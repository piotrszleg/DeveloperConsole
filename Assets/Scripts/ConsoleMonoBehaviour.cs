using UnityEngine;

// Simplifies registration of objects inheriting directly from MonoBehaviour.
// Note that there are some limitations where it comes to accessing inherited
// fields using reflection described in the library documentation.
public abstract class ConsoleMonoBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        // Console.Register(this);
    }

    protected virtual void OnDestroy()
    {
        // Console.Unregister(this);
    }
}
