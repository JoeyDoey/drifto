using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public Text clippingPointsText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.FindWithTag("GameController").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore();
    }
}
