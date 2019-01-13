using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 MoveVector = Vector3.zero;

    [SerializeField] float moveSpeed = 5f;

    new Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        if (MoveVector.sqrMagnitude > 1)
            MoveVector.Normalize();

        Vector3 movement = MoveVector * moveSpeed;

        rigidbody.MovePosition(transform.position + movement * Time.deltaTime);
    }

    void Turn ()
    {
        if (MoveVector == Vector3.zero)
            return;

        rigidbody.MoveRotation(Quaternion.LookRotation(MoveVector));
    }
}
