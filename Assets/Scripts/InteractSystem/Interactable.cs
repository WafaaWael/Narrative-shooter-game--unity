using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent events;
    private bool interacted=false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacted = true;
            playerInteract();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        interacted = false;

    }

    private void Update()
    {
    }

    private void playerInteract()
    {
        if (interacted)
        {
            {
                events.Invoke();
                interacted = false;

            }
        }
    }
}
