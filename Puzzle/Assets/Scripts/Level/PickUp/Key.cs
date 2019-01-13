using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory == null)
                return;

            // Check if inventory has space
            if (inventory.IsEmpty())
            {
                // Add to inventory
                inventory.AddKey(this);
                // Destroy key
                Destroy(gameObject);
            }
        }
    }
}
