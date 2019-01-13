using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public GameObject itemAvailable;
    bool carrying = false;

    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (carrying)
            {
                Drop();
            }
            else
            {
                PickUp();
            }
        }
    }

    void PickUp ()
    {
        if (itemAvailable == null) return;

        itemAvailable.GetComponent<SphereCollider>().enabled = false;

        itemAvailable.transform.parent = transform;
        itemAvailable.transform.localPosition = new Vector3(0, itemAvailable.GetComponent<BoxCollider>().size.y /2, capsuleCollider.radius + 0.1f + itemAvailable.GetComponent<BoxCollider>().size.z / 2);
        itemAvailable.transform.localRotation = Quaternion.identity;

        carrying = true;
    }

    void Drop ()
    {
        if (itemAvailable == null) return;

        itemAvailable.GetComponent<SphereCollider>().enabled = true;

        itemAvailable.transform.parent = GameManager.Instance.props;
        carrying = false;
    }
}
