using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    [TextArea(3, 5)] // << Creates a text box with parameters, in this case 3 lines minimum, a scroll bar shows after 5 lines.
    [SerializeField] private string message = "Default message";

    [SerializeField] private float messageDuration = 1.0f;

    public delegate void ContextualMessageTriggeredAction(); // Delegate - Can only store void methods with no parameters, this can be
                                                             // avoided going forward with either a FUNC and an ACTION (void) in C#. 
    //We can then make the next line change from:

    // public static event ContextualMessageTriggeredAction ContextualMessageTriggered; // Static (need no reference) event to observe

    // To:

    public static event Action<String, float> ContextualMessageTriggered; // Needs: using Systems, and we can pass up to 16 parameters


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Anounce/Broadcast when the event occurs
            if(ContextualMessageTriggered != null)
            {
            ContextualMessageTriggered.Invoke(message, messageDuration);
            }
        }
    }
}


