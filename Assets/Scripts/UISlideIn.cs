using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UISlideIn : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 startAnchoredPosition;
    bool playing;
    public float speed = 1;
    public float distanceMultiplier = 1.5f;

    void Awake()
    {
        playing = false;
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPosition = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector2(-rectTransform.rect.width * distanceMultiplier, rectTransform.anchoredPosition.y);
    }

    public void Play()
    {
        playing = true;
    }

    void Update()
    {
        if (playing)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, startAnchoredPosition, Time.deltaTime * speed);
        }
    }
}
