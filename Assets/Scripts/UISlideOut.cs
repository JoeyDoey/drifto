﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UISlideOut : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 startAnchoredPosition;
    Vector2 finalAnchoredPosition;
    bool playing;
    float currentPlayTime;
    public float playTime = 1;
    public float distanceMultiplier = 1.5f;

    void Awake()
    {
        playing = false;
        rectTransform = GetComponent<RectTransform>();
        finalAnchoredPosition = new Vector2(rectTransform.rect.width * distanceMultiplier, rectTransform.anchoredPosition.y);
        startAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void Play()
    {
        playing = true;
        currentPlayTime = 0;
    }

    void Update()
    {
        if (playing)
        {
            rectTransform.anchoredPosition = GetNewPosition(currentPlayTime / playTime, startAnchoredPosition, finalAnchoredPosition);
            currentPlayTime = Mathf.Min(1, currentPlayTime + Time.deltaTime);
            // TODO make variable play time
        }
    }

    Vector2 GetNewPosition(float t, Vector2 start, Vector2 end) {
        return new Vector2(Interpolate(t, start.x, end.x), Interpolate(t, start.y, end.y));
    }

    float Interpolate(float t, float start, float end) {
        return start + (end - start) * t * t;
    }

    float SlideFunction(float t) {
        return t;
    }
}