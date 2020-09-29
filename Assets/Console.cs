using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class TextEvent : UnityEvent<string>
{
}

public class Console : MonoBehaviour
{
    public InputField input;
    public Text text;
    public TextEvent onInput;

    void Start()
    {
        input.onEndEdit.AddListener(TextSubmitted);
        text.text = "";
    }

    void TextSubmitted(string text) {
        Write(text);
        onInput.Invoke(text);
        input.text = "";
        input.ActivateInputField();
    }

    public void Write(string toWrite)
    {
        text.text += '\n' + toWrite;
    }
}
