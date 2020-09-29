using UnityEngine;

public class Cube : MonoBehaviour
{
    [Console]
    void Move(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }

    void Start()
    {
        Console.Register(this);
    }

    void OnDestroy()
    {
        Console.Unregister(this);
    }
}
