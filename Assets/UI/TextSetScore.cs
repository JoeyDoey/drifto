using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSetScore : MonoBehaviour
{
    [System.Serializable]
    public enum ScoreType
    {
        score,
        multiplier,
        clippingPoints,
    }

    public string prefix = "";
    public ScoreType scoreType;
    TextMeshProUGUI textPro;
    public GameController.AScoreController scoreHandler;

    private void Awake() {
        textPro = GetComponent<TextMeshProUGUI>();     
    }

    void Update()
    {
        if (textPro) textPro.text = prefix + Mathf.Floor(GetScore()).ToString();
    }

    float GetScore()
    {
        switch (scoreType)
        {
            case ScoreType.score:
                return scoreHandler.GetScore();
            case ScoreType.multiplier:
                return scoreHandler.GetMultiplier();
            case ScoreType.clippingPoints:
                return scoreHandler.GetClippingPoints();
        }
        return scoreHandler.GetScore();
    }
}
