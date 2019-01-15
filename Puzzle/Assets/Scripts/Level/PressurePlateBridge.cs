using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBridge : MonoBehaviour
{
    [SerializeField] GameObject triggerableObject = null;
    [SerializeField] string pressParam = "press";
    [SerializeField] bool needWeight = true;

    Animator animator;

    int pressObjectCount = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        pressObjectCount++;

        animator.SetTrigger(pressParam);

        if (triggerableObject != null)
            GameManager.Instance.OpenBridge(triggerableObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
            return;

        pressObjectCount--;
        if (pressObjectCount > 0) return;

        if (needWeight)
        {
            animator.SetTrigger(pressParam);

            if (triggerableObject != null)
                GameManager.Instance.CloseBridge(triggerableObject);
        }
    }
}
