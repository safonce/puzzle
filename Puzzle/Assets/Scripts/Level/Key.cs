using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject triggerableObject = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory pi = other.GetComponent<PlayerInventory>();

        if (pi == null)
            return;

        if (pi.IsEmpty())
        {
            pi.item = this;
            gameObject.SetActive(false);
        }
    }
}
