using UnityEngine;
using UnityEngine.UI;

public class Title : ConsoleMonoBehaviour
{
    Text text;

    // [Command]
    void SetTitle(string value)
    {
        text.text = value;
    }

    // [Command]
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
