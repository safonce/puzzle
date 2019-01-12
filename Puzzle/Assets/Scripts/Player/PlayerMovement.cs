using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool isPlayerOne;

    [SerializeField] float moveSpeed = 5f;

    new Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector3 moveInput = Vector3.zero;

        if (isPlayerOne)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));
        }

        Vector3 moveVector = Camera.main.transform.TransformDirection(moveInput);
        moveVector.y = 0;

        Move(moveVector);
        Turn(moveVector);
    }

    void Move(Vector3 moveVector)
    {
        if (moveVector.sqrMagnitude > 1)
            moveVector.Normalize();

        Vector3 movement = moveVector * moveSpeed;

        rigidbody.MovePosition(transform.position + movement * Time.deltaTime);
    }

    void Turn (Vector3 moveVector)
    {
        if (moveVector == Vector3.zero)
            return;

        rigidbody.MoveRotation(Quaternion.LookRotation(moveVector));
    }
}
