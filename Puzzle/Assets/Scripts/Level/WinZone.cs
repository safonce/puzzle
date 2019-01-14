using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    int countPlayer = 0;

    private void OnTriggerEnter(Collider other)
    {
        countPlayer++;
        if (countPlayer == 2)
            GameManager.Instance.Win();
    }

    private void OnTriggerExit(Collider other)
    {
        countPlayer--;
        if (countPlayer < 0)
            countPlayer = 0;
    }
}
