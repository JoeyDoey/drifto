using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public Car.Car car;
    public float masterMultiplier = 1f;
    public float minDriftAngle = 5f;
    public float minSpeed = 5f;
    float score = 0;
    [Header("Drift Time Multiplier")]
    public float multiplerDecaySpeed = 1f;
    public float timeMultiplerScale = 1f;
    float timeSinceDrift;
    float currentMultiplier = 0;
    float lastUndecayedMultiplier;
    [Header("Clipping Points")]
    public Transform clippingPoints;
    public float minClippingPointScore = 2f;
    public float maxClippingPointScore = 10f;
    public float maxClippingPointDistance = 5f;
    public float minClippingPointDistance = 1f;
    public ClippingPointEvent onClippingPoint;

    void Start()
    {
        score = 0;
        timeSinceDrift = 0;
    }

    void Update()
    {
        UpdateMultiplier(IsDrifting());
        score += GetInstantScore() * Time.deltaTime * masterMultiplier;
    }

    void FixedUpdate()
    {
        UpdateClipping();
    }

    public float GetScore()
    {
        return score;
    }

    bool IsDrifting()
    {
        return Mathf.Abs(car.GetDriftAngle()) >= minDriftAngle && Mathf.Abs(car.GetVelocity().magnitude) >= minSpeed;
    }

    void UpdateClipping()
    {
        int i = 0;
        foreach (Transform trans in clippingPoints)
        {
            ClippingPoint clip = trans.gameObject.GetComponent<ClippingPoint>();
            if (!clip.IsDisabled() && clip.IsTouching(car.frontCheck.position))
            {
                float distance = clip.GetDistanceTo(car.frontCheck.position);
                if (distance <= maxClippingPointDistance)
                {
                    clip.TempDisable();

                    float scoreRange = (maxClippingPointScore - minClippingPointScore);
                    float t = 1 - Mathf.Max(distance - minClippingPointDistance, 0) / maxClippingPointDistance;
                    float pointScore = (minClippingPointScore + scoreRange * t);

                    int s = (int) pointScore;
                    score += s;
                    onClippingPoint.Invoke(s, i);
                }
            }
            i++;
        }
    }

    void UpdateMultiplier(bool isDrifting)
    {
        if (!isDrifting)
        {
            timeSinceDrift += Time.deltaTime;

            // Decay the multiplier
            currentMultiplier = Mathf.Max(0, lastUndecayedMultiplier - timeSinceDrift * timeSinceDrift * multiplerDecaySpeed);
        }
        else
        {
            currentMultiplier += Time.deltaTime * timeMultiplerScale;
            lastUndecayedMultiplier = currentMultiplier;
            timeSinceDrift = 0;
        }
    }

    public float GetMultiplier()
    {
        return currentMultiplier;
    }

    float GetInstantScore()
    {
        float angle = Mathf.Abs(car.GetDriftAngle());
        float speed = Mathf.Abs(car.GetVelocity().magnitude);

        if (angle < minDriftAngle) angle = 0;
        if (speed < minSpeed) speed = 0;

        float rawScore = angle * speed;
        return rawScore * GetMultiplier();
    }
}

/// <summary>
/// (score, index)
/// </summary>
[System.Serializable]
public class ClippingPointEvent : UnityEvent<int, int>
{
}
