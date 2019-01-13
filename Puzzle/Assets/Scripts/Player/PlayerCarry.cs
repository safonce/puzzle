using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [HideInInspector] public GameObject itemAvailable = null;
    [HideInInspector] public bool Carrying = false;

    [SerializeField] float zOffset = 0.1f;


    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void PickUp ()
    {
        if (itemAvailable == null) return;

        itemAvailable.GetComponent<SphereCollider>().enabled = false;

        itemAvailable.transform.parent = transform;
        itemAvailable.transform.localPosition = new Vector3(0, itemAvailable.GetComponent<BoxCollider>().size.y /2, 
                                    capsuleCollider.radius + zOffset + itemAvailable.GetComponent<BoxCollider>().size.z / 2);
        itemAvailable.transform.localRotation = Quaternion.identity;

        Carrying = true;
    }

    public void Drop ()
    {
        if (itemAvailable == null) return;

        itemAvailable.GetComponent<SphereCollider>().enabled = true;

        itemAvailable.transform.parent = GameManager.Instance.props;
        Carrying = false;
    }
}
