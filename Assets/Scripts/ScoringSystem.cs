using System.Collections;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private int multiplier = 1;

    public GameObject textGameObject;
    private TMP_Text text;

    private void Awake()
    {
        StartCoroutine(nameof(WaitAndRegister));
        text = textGameObject.GetComponent<TMP_Text>();
        StaticScore.CrossSceneBestMultiplier = 0;
        StaticScore.CrossSceneFullBoxes = 0;
        StaticScore.CrossSceneScore = 0;
    }

    private void Update()
    {
        text.text = "Scoring : " + StaticScore.CrossSceneScore + "\nMultiplier : x" + multiplier;
    }

    private void OnSuccessfulTractHitMailbox()
    {
        StaticScore.CrossSceneScore += 1 * multiplier++;
        Debug.Log("[SCORING] Tract hit, score is " + StaticScore.CrossSceneScore + ", multiplier is" + multiplier);
    }

    private void OnTractMiss()
    {
        if (multiplier > StaticScore.CrossSceneBestMultiplier)
        {
            StaticScore.CrossSceneBestMultiplier = multiplier;
        }
        multiplier = 1;
        Debug.Log("[SCORING] Tract missed, resetting multiplier");
    }

    private void OnMailboxFullyFilled()
    {
        StaticScore.CrossSceneScore += 10 * multiplier;
        StaticScore.CrossSceneFullBoxes++;
        Debug.Log("[SCORING] Mailbox is full, score is " + StaticScore.CrossSceneScore + ", multiplier is" + multiplier);
    }

    IEnumerator WaitAndRegister()
    {
        yield return new WaitForSeconds(.5f);
        EventSystem.Instance.OnMailboxHit += OnSuccessfulTractHitMailbox;
        EventSystem.Instance.OnMailboxFullyFilled += OnMailboxFullyFilled;
        EventSystem.Instance.OnTractMissed += OnTractMiss;
    }
}
