using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextuaMessageController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TMP_Text messegeText; // TextMesh Pro

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messegeText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;
    }

    private void ShowMessage(string message, float duration) // Providing parameters to avoid multiple instances of method
    {
        messegeText.text = message;
    }
}
