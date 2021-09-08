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
    public Color baseColor = Color.white;

    void Start()
    {
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
            texts[i].color = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a * FadeFunction(timers[i] / displayTime));
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
