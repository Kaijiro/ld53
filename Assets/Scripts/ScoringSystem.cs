using System;
using System.Collections;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField]
    private int multiplier = 1;

    [SerializeField]
    private int score = 0;

    private void Awake()
    {
        StartCoroutine(nameof(WaitAndRegister));
    }

    private void OnSuccessfulTractHitMailbox()
    {
        score += 1 * multiplier++;
        Debug.Log("[SCORING] Tract hit, score is " + score + ", multiplier is" + multiplier);
    }

    private void OnTractMiss()
    {
        multiplier = 1;
        Debug.Log("[SCORING] Tract missed, resetting multiplier");
    }

    private void OnMailboxFullyFilled()
    {
        score += 10 * multiplier;
        Debug.Log("[SCORING] Mailbox is full, score is " + score + ", multiplier is" + multiplier);
    }

    IEnumerator WaitAndRegister()
    {
        yield return new WaitForSeconds(.5f);
        EventSystem.Instance.OnMailboxHit += OnSuccessfulTractHitMailbox;
        EventSystem.Instance.OnMailboxFullyFilled += OnMailboxFullyFilled;
        EventSystem.Instance.OnTractMissed += OnTractMiss;
    }
}
