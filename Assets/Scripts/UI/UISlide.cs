using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UISlide : MonoBehaviour
{
    RectTransform rectTransform;
    public float distanceMultiplier = 1.5f;
    public float startSide = -1;
    Vector2 centerPosition;
    Vector2 maxOffset;
    float goal;
    public float speed = 100000;
    public float dampingFactor = 0.5f;
    Vector2 velocity;

    void Awake()
    {
        velocity = Vector2.zero;
        rectTransform = GetComponent<RectTransform>();
        centerPosition = rectTransform.anchoredPosition;
        maxOffset = new Vector2(rectTransform.rect.width * distanceMultiplier, 0);
        rectTransform.anchoredPosition = centerPosition + maxOffset * startSide;
        goal = startSide;
    }

    public void SlideToLeft()
    {
        goal = -1;
    }

    public void SlideToCenter()
    {
        goal = 0;
    }

    public void SlideToRight()
    {
        goal = 1;
    }

    void Update()
    {
        float current = GetCurrentDistance();
        float distance = goal - current;
        velocity += Vector2.right * distance * speed * Time.deltaTime;
        velocity *= dampingFactor;   // Damping
        rectTransform.anchoredPosition += velocity * Time.deltaTime;
    }

    /// <summary>
    /// How far between -maxOffset and maxOffset are we (-1 to 1)
    /// </summary>
    float GetCurrentDistance()
    {
        float ldist = (rectTransform.anchoredPosition - (centerPosition - maxOffset)).magnitude;
        float maxDist = maxOffset.magnitude * 2;
        return (ldist / maxDist) * 2 - 1;
    }

    Vector2 GetNewPosition(float t, Vector2 start, Vector2 end)
    {
        return new Vector2(Interpolate(t, start.x, end.x), Interpolate(t, start.y, end.y));
    }

    float Interpolate(float t, float start, float end)
    {
        return start + (end - start) * t * t;
    }

    float SlideFunction(float t)
    {
        return t;
    }
}
