using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClippingPointUI : MonoBehaviour
{
    public Text[] texts;
    float[] timers;
    public float displayTime = 1;
    public int pointsPerBurst = 3;
    public int maxFontSize = 100;
    int normalFontSize;
    public Color baseColor = Color.white;

    void Start()
    {
        normalFontSize = texts[0].fontSize;
        timers = new float[pointsPerBurst];
        for (int i = 0; i < pointsPerBurst; i++)
        {
            timers[i] = 0;
        }
    }

    void Update()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            timers[i] = Mathf.Max(0, timers[i] - Time.deltaTime);
            if (timers[i] > 0) {
                texts[i].color = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a * FadeFunction(timers[i] / displayTime));
                texts[i].fontSize = (int) Mathf.Max(normalFontSize, (maxFontSize * (timers[i] / displayTime)));
            } else {
                texts[i].color = new Color(baseColor.r, baseColor.g, baseColor.b, 0);
            }
        }
    }

    public void Set(int newScore, int index)
    {
        texts[index % pointsPerBurst].text = newScore.ToString();
        timers[index % pointsPerBurst] = displayTime;
    }

    float FadeFunction(float t)
    {
        return 1 - Mathf.Pow(1 - t, 10);
    }
}
