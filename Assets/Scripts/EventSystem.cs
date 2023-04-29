using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action OnMailboxHit;
    public void MailboxHit()
    {
        OnMailboxHit?.Invoke();
    }

    public event Action OnMailboxFullyFilled;
    public void MailboxFullyFilled()
    {
        OnMailboxFullyFilled?.Invoke();
    }

    public event Action OnTractMissed;
    public void TractMissed()
    {
        OnTractMissed?.Invoke();
    }
}
