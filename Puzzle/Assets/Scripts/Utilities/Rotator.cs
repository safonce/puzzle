using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector = Vector3.zero;

    private void FixedUpdate()
    {
        transform.Rotate(rotateVector * Time.deltaTime);
    }
}
