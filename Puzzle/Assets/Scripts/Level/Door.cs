using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject door = null;
    [SerializeField] bool requireKey = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!requireKey)
            return;

        PlayerInventory pi = other.GetComponent<PlayerInventory>();

        if (pi == null)
            return;

        pi.availableDoor = door;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!requireKey)
            return;

        PlayerInventory pi = other.GetComponent<PlayerInventory>();

        if (pi == null)
            return;

        pi.availableDoor = null;
    }
}
