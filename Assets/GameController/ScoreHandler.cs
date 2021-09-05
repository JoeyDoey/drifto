using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public Car.Car car;
    public float masterMultiplyer = 1f;
    float score = 0;
    public float minDriftAngle = 5f;
    public float minSpeed = 5f;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        score += GetInstantScore(car) * Time.deltaTime * masterMultiplyer;
    }

    public float GetScore()
    {
        return score;
    }

    float GetInstantScore(Car.Car car)
    {
        float angle = Mathf.Abs(car.GetDriftAngle());
        float speed = Mathf.Abs(car.GetVelocity().magnitude);

        if (angle < minDriftAngle) angle = 0;
        if (speed < minSpeed) speed = 0;

        return angle * speed;
    }
}
