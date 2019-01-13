using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Key requiredKey  = null;
    [SerializeField] GameObject doorObject = null;

    bool unlock = false;

    private void OnTriggerEnter(Collider other)
    {
        if (unlock)
            return;

        if (other.CompareTag("Player"))
        {
            // Check if key is required
            if (IsRequiredKey())
            {
                // Make sure player has inventory
                PlayerInventory inventory = other.GetComponent<PlayerInventory>();
                if (inventory == null)
                    return;

                // Check if player has the key in the inventory
                if (inventory.HasKey(requiredKey))
                {
                    // If key is found then unlock and open the door
                    GameManager.Instance.OpenDoor(doorObject);
                    unlock = true;
                }
            }
            else
            {
                GameManager.Instance.OpenDoor(doorObject);
            }
        }
    }

    bool IsRequiredKey ()
    {
        return requiredKey != null;
    }
}
