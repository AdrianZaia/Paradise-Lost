using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public InputField inputField; // Drag the InputField GameObject into this field in the Unity Inspector
    public Text outputText;       // Drag the Text GameObject into this field in the Unity Inspector

    void Start()
    {
        // Complete the code to subscribe to the InputField's onValueChanged event
        inputField.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(string text)
    {
        // Complete this method to update the outputText with the inputField's text
        outputText.text = text;
    }
}