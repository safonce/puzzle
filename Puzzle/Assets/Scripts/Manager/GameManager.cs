using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform props = null;

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

    private void Start()
    {
        
    }
    public void OpenDoor (GameObject door)
    {
        door.SetActive(false);
    }

    public void CloseDoor(GameObject door)
    {
        door.SetActive(true);
    }

    public void OpenBridge(GameObject bridge)
    {
        bridge.SetActive(true);
    }

    public void CloseBridge(GameObject bridge)
    {
        bridge.SetActive(false);
    }


    public void GameOver ()
    {
        LevelManager.Instance.RestartLevel();
    }

    public void Win ()
    {
        int currentLevel = LevelManager.Instance.CurrentScene() + 1;
        LevelManager.Instance.LoadScene(currentLevel);
    }
}
