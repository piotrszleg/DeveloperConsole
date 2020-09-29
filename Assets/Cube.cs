using UnityEngine;

public class Cube : ConsoleMonoBehaviour
{
    [Console]
    void Move(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }
}
