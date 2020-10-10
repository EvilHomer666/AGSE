using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    public delegate void ContextualMessageTriggeredAction(); // Can only store void methods with no parameters

    public static event ContextualMessageTriggeredAction ContextualMessageTriggered; // Static

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Anounce when the event occurs
            if(ContextualMessageTriggered != null)
            {
            ContextualMessageTriggered.Invoke();
            }
        }
    }
}


