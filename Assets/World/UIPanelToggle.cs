using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelToggle : MonoBehaviour
{
    public GameObject panel; // Drag the panel GameObject into this field in the Unity Inspector
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TogglePanel);
        panel.SetActive(false);
    }

    void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}