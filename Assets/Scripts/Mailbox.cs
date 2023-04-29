using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public bool isFull = false;
    private bool hasMoved = false; // Debug flag, remove later

    private Transform flagTransform;

    private void Start()
    {
        flagTransform = transform.GetChild(0).Find("Cylinder");
    }

    public void Update()
    {
        // Should be fired by an event later
        if (!isFull || hasMoved) return;

        RaiseFlag();
        hasMoved = true;
    }

    private void RaiseFlag() // May be public ?
    {
        var newFlagRotation = Quaternion.Euler(0, 0, -90);
        flagTransform.rotation *= newFlagRotation;
    }
}
