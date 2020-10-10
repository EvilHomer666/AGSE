using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextuaMessageController : MonoBehaviour
{
    [SerializeField] float fadeOutDuration = 1;

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

        // start fading out
        float fadeElapsedTime = 0;
        float fadeStartTime = Time.time;
        while (fadeElapsedTime < fadeOutDuration) // This loop only governs this coroutine, not the entire program
        {
            fadeElapsedTime = Time.time - fadeStartTime;
            canvasGroup.alpha = 1 - fadeElapsedTime / fadeOutDuration;
            yield return null; // Must exist or game will freeze
        }
        canvasGroup.alpha = 0;
    }

    // Create an event handler - thsi function decopples/encapsulates the two scripts, ContextuaMessageController and 
    // ContextualMessageTrigger so they can communicate with each other without depending on each other through references. 
    // Separation of concerns!.
    private void OnContextualMessageTriggered(string message, float messageDuration)
    {
        StopAllCoroutines(); // << Prevents stacking of coroutines so each has their own timer
        StartCoroutine(ShowMessage(message, messageDuration));
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
