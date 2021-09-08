using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClippingPointUI : MonoBehaviour
{
    public Text[] texts;
    public int pointsPerBurst = 3;

    void Start()
    {
        foreach (Text text in texts)
        {
            text.gameObject.SetActive(false);
        }
    }

    void Update()
    {
    }

    public void Set(int newScore, int index)
    {
        texts[index % pointsPerBurst].gameObject.SetActive(true);
        texts[index % pointsPerBurst].text = newScore.ToString();
    }
}
