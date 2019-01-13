using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCarry pc = other.GetComponent<PlayerCarry>();

        if (pc == null)
            return;

        pc.itemAvailable = this.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerCarry pc = other.GetComponent<PlayerCarry>();

        if (pc == null)
            return;

        pc.itemAvailable = null;
    }
}
