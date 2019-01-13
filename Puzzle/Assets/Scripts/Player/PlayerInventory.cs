using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject availableDoor = null;

    public Key item;

    private void Update()
    {
       if (availableDoor & Input.GetKeyUp(KeyCode.E))
        {
            UseItem();
        }
    }

    public void UseItem ()
    {
        if (item.triggerableObject != availableDoor)
            return;

        availableDoor.GetComponentInParent<BoxCollider>().enabled = false;

        GameManager.Instance.OpenDoor(availableDoor);

        item = null;
    }

    public bool IsEmpty()
    {
        return item == null;
    }
}
