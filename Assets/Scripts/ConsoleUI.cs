using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class TextEvent : UnityEvent<string>
{
}

public class ConsoleUI : MonoBehaviour
{
    public InputField input;
    public Text text;
    public TextEvent onInput;

    Queue<string> lines = new Queue<string>();
    public int maxLines = 10;

    void Start()
    {
        input.onEndEdit.AddListener(TextSubmitted);
        text.text = "";
    }

    void TextSubmitted(string text) {
        if (text != "")
        {
            Write("> " + text);
            onInput.Invoke(text);
            input.text = "";
        }
        input.ActivateInputField();
    }

    public void Write(string toWrite)
    {
        lines.Enqueue(toWrite);
        if (lines.Count > maxLines)
        {
            lines.Dequeue();
        }
        text.text = lines.Aggregate((value, accumulator) => value + '\n' + accumulator);
    }
}
