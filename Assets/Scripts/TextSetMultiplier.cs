using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetMultiplier : MonoBehaviour
{
    public Text text;
    public ScoreHandler scoreHandler;

    void Update()
    {
        text.text = Mathf.Floor(scoreHandler.GetMultiplier()).ToString();
    }
}
