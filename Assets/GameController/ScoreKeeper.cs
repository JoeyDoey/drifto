using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private float score;
    public CarController car;
    public float minAngle = 10;
    public float minSpeed = 10;
    public float masterMultiplier = 0.1f;

    void Start()
    {
        score = 0;        
    }

    void Update()
    {
        score += GetRawScore(car.RB.velocity.magnitude, GetDriftAngle()) * Time.deltaTime * masterMultiplier;
    }

    float GetDriftAngle() {
        // return Vector2.Angle(new Vector2(car.RB.velocity.x, car.RB.velocity.z), new Vector2(transform.forward.x, transform.forward.z));
        return car.VelocityAngle;
    }

    public int GetScore() {
        return (int) score;
    }

    /// <summary>
    /// Get the score without a multiplier added
    /// </summary>
    /// <param name="speed">Speed in the direction the car is travelling</param>
    /// <param name="angle">Drift angle in degrees</param>
    /// <returns></returns>
    float GetRawScore(float speed, float angle) {
        return Mathf.Max(0, Mathf.Abs(angle) - minAngle) * Mathf.Max(0, Mathf.Abs(speed) - minSpeed);
    }
}
