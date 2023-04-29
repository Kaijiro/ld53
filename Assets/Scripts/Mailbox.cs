using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    public int capacity = 10;
    public bool isFull = false;

    private Transform flagTransform;

    private void Start()
    {
        flagTransform = transform.GetChild(0).Find("Cylinder");
    }

    private void RaiseFlag()
    {
        var newFlagRotation = Quaternion.Euler(0, 0, -90);
        flagTransform.rotation *= newFlagRotation;
    }

    public void OnProjectileHit()
    {
        if (isFull) return;

        capacity--;
        EventSystem.Instance.MailboxHit();

        if (capacity == 0)
        {
            EventSystem.Instance.MailboxFullyFilled();
            RaiseFlag();
        }
    }
}
