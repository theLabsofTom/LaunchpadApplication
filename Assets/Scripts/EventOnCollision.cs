using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    public UnityEvent TriggerEntered;
    public string Tag;
    public UnityEvent TriggerEnteredByTag;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            TriggerEnteredByTag.Invoke();
        }
        else
        {
            TriggerEntered.Invoke();
        }
    }
}
