using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCarry player = other.GetComponent<PlayerCarry>();
            if (player == null)
                return;

            if (!player.Carrying)
                player.itemAvailable = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCarry player = other.GetComponent<PlayerCarry>();

            if (player == null)
                return;

            if (!player.Carrying)
                player.itemAvailable = null;
        }
    }
}
