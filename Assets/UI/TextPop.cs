using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPop : MonoBehaviour
{
    TextMeshProUGUI text;
    float originalSize;
    public float popSizeScale = 1.5f;
    public float playTime = 0.5f;
    float currentPlayTime;
    public bool playOnChange;
    string lastText;

    private void Awake()
    {
        TryGetComponent(out text);
        originalSize = text.fontSize;
        lastText = text.text;
    }

    void Update()
    {
        if (playOnChange)
        {
            if (lastText != text.text) Play();
            lastText = text.text;
        }

        if (currentPlayTime < playTime)
        {
            currentPlayTime = Mathf.Min(currentPlayTime + Time.deltaTime, 1);
            text.fontSize = Mathf.FloorToInt(GetSizeMultiplier(currentPlayTime / playTime) * originalSize);
        }
    }

    float GetSizeMultiplier(float t)
    {
        float s = (1 - t);
        return 1 + s * (popSizeScale - 1);
    }

    public void Play()
    {
        currentPlayTime = 0;
    }
}
