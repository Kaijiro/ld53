using UnityEngine;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI bestMultiplier;
    public TextMeshProUGUI fullBoxes;
    public TextMeshProUGUI missedBoxes;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        
        finalScore.SetText( StaticScore.CrossSceneScore.ToString());
        bestMultiplier.SetText("x"+StaticScore.CrossSceneBestMultiplier.ToString());
        fullBoxes.SetText(StaticScore.CrossSceneFullBoxes.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}