using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreUI : MonoBehaviour
{
    private void Start()
    {
        Text score = GetComponent<Text>();
        score.text = "SCORE: " + FinalScoreManager.Instance.finalScore;
    }
}
