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

        //StartCoroutine (ShowMessage("Testing", 2));
    }

    private IEnumerator ShowMessage(string message, float duration) //Co-routine Providing parameters to avoid multiple instances of method
    {
        canvasGroup.alpha = 1;
        messegeText.text = message;
        // Wait for duration
        yield return new WaitForSeconds(duration);
        canvasGroup.alpha = 0;
    }

    // Create an event handler - thsi function decopples/encapsulates the two scripts, ContextuaMessageController and 
    // ContextualMessageTrigger so they can communicate with each other without depending on each other through references. 
    // Separation of concerns!.
    private void OnContextualMessageTriggered()
    {
        StartCoroutine(ShowMessage("Testing", 2));
    }

    private void OnEnable()
    {
        // Subscrive - store event handler in the event
        ContextualMessageTrigger.ContextualMessageTriggered += OnContextualMessageTriggered;
    }

    private void OnDisable()
    {
        // Unsubscribe - remove the event handler
        ContextualMessageTrigger.ContextualMessageTriggered -= OnContextualMessageTriggered;
    }

}
