using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetScore : MonoBehaviour
{
    public Text text;
    public GameController.AScoreController scoreHandler;

    void Update()
    {
        text.text = Mathf.Floor(scoreHandler.GetScore()).ToString();
    }
}
