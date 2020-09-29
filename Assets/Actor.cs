using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [Console]
    void Move(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }

    void Start()
    {
        DeveloperConsole.Register(this);
    }
}
