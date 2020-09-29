using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    Text text;

    [Console]
    void SetTitle(string value)
    {
        text.text = value;
    }

    [Console]
    string GetTitle()
    {
        return text.text;
    }

    void Start()
    {
        text = GetComponent<Text>();
        Console.Register(this);
    }

    void OnDestroy()
    {
        Console.Unregister(this);
    }
}
