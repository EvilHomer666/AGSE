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


}
