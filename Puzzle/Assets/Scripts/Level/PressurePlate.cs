using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject triggerableObject = null;
    [SerializeField] string pressParam = "press";
    [SerializeField] bool needWeight = true;

    Animator animator;

    public List<GameObject> pressingObject = new List<GameObject>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        pressingObject.Add(other.gameObject);

        animator.SetTrigger(pressParam);

        if (triggerableObject != null)
            GameManager.Instance.OpenDoor(triggerableObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
            return;

        pressingObject.Remove(other.gameObject);

        if (pressingObject.Count > 0)
            return;

        if (needWeight)
        {
            animator.SetTrigger(pressParam);

            if (triggerableObject != null)
                GameManager.Instance.CloseDoor(triggerableObject);
        }
    }
}
