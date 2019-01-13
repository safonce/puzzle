using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public Key key;

    public bool HasKey(Key requiredKey)
    {
        // Compare inventory key with door key
        if (key == requiredKey)
            return true;

        return false;
    }

    public void AddKey(Key newKey)
    {
        key = newKey;
    }

    public bool IsEmpty ()
    {
        return key == null;
    }
}
