using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] string horizontal = "Horizontal";
    [SerializeField] string vertical = "Vertical";

    PlayerMovement playerMovement;
    PlayerCarry playerCarry;

    Transform camTransform;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCarry = GetComponent<PlayerCarry>();

        camTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        SetMoveDirection();
        SetAction();
    }

    void SetMoveDirection ()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw(horizontal), 0, Input.GetAxisRaw(vertical));

        if (playerMovement == null)
            return;

        if (camTransform == null)
            playerMovement.MoveVector = moveInput;
        else
        {
            Vector3 camMoveVector = camTransform.TransformDirection(moveInput);
            camMoveVector.y = 0;
            playerMovement.MoveVector = camMoveVector;
        }
    }

    void SetAction ()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (playerCarry.Carrying)
                playerCarry.Drop();
            else
                playerCarry.PickUp();
        }
    }
}
