using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public Car.Car car;
    public float masterMultiplier = 1f;
    public float minDriftAngle = 5f;
    public float minSpeed = 5f;
    public float multiplerDecaySpeed = 1f;
    public float timeMultiplerScale = 1f;
    float currentMultiplier = 0;
    float score = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        UpdateMultiplier(IsDrifting());
        score += GetInstantScore() * Time.deltaTime * masterMultiplier;
    }

    public float GetScore()
    {
        return score;
    }

    bool IsDrifting()
    {
        return Mathf.Abs(car.GetDriftAngle()) >= minDriftAngle && Mathf.Abs(car.GetVelocity().magnitude) >= minSpeed;
    }

    void UpdateMultiplier(bool isDrifting)
    {
        if (!isDrifting)
        {
            currentMultiplier = 0;
        }
        else
        {
            currentMultiplier += Time.deltaTime * timeMultiplerScale;
        }
    }

    float GetMultiplier()
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
