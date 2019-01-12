using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
    
    public void OpenDoor (GameObject door)
    {
        door.SetActive(false);
    }

    public void CloseDoor(GameObject door)
    {
        door.SetActive(true);
    }
}
