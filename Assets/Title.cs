using UnityEngine;
using UnityEngine.UI;

public class Title : ConsoleMonoBehaviour
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

    protected override void Start()
    {
        base.Start();
        text = GetComponent<Text>();
    }
}
