using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Console : MonoBehaviour
{
    public InputField input;
    public Text text;

    void Start()
    {
        input.onEndEdit.AddListener(TextSubmitted);
    }

    void TextSubmitted(string text) {
        Write(text);
        input.text = "";
        input.ActivateInputField();
    }

    public void Write(string toWrite)
    {
        text.text += '\n' + toWrite;
    }
}
