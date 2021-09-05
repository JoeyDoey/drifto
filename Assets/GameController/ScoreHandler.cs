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
    float currentDriftTime = 0;
    float score = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        score += GetInstantScore(car) * Time.deltaTime * masterMultiplier;
    }

    public float GetScore()
    {
        return score;
    }

    float UpdateTimeMultiplier(bool isDrifting)
    {
        if (!isDrifting)
        {
            currentDriftTime = 0;
        }
        else
        {
            currentDriftTime += Time.deltaTime;
        }
        return currentDriftTime;
    }

    float GetInstantScore(Car.Car car)
    {
        float angle = Mathf.Abs(car.GetDriftAngle());
        float speed = Mathf.Abs(car.GetVelocity().magnitude);

        if (angle < minDriftAngle) angle = 0;
        if (speed < minSpeed) speed = 0;

        float rawScore = angle * speed;
        return rawScore * UpdateTimeMultiplier(rawScore != 0);
    }
}
