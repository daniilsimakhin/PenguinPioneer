using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    public CanvasGroup canvasGroup;

    public string GetTextLabel => _label.text;

    public void SetTextLabel(string text)
    {
        _label.text = text;
    }
}
