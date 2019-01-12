using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject triggerableObject = null;
    [SerializeField] string pressParam = "press";
    [SerializeField] bool needWeight = true;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(pressParam);

        if (triggerableObject != null)
            GameManager.Instance.OpenDoor(triggerableObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (needWeight)
        {
            animator.SetTrigger(pressParam);

            if (triggerableObject != null)
                GameManager.Instance.CloseDoor(triggerableObject);
        }
    }
}
