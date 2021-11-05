using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameController
{
    /// Takes into consideration speed, angle, time in drift, and 
    /// </summary>
    public class ScoreController : AScoreController
    {
        public Car.Car car;
        float score;
        float currentDriftTime;
        float timeSinceDrift;
        float currentRunScore;

        void Awake()
        {
            score = 0;
            currentRunScore = 0;
            currentDriftTime = 0;
            timeSinceDrift = 0;
        }

        private void Update()
        {
            if (car.IsDrifting())
            {
                // currentRunScore += GetInstantScore() * Time.deltaTime * masterMultiplier;
                score += GetInstantScore() * Time.deltaTime * masterMultiplier;
                currentDriftTime += Time.deltaTime;
                timeSinceDrift = 0;
            }
            else if (timeSinceDrift < maxTimeBetweenDrift)
            {
                timeSinceDrift += Time.deltaTime;
            }
            else
            {
                currentDriftTime = 0;
                score += currentRunScore;
                currentRunScore = 0;
            }
        }

        public override float GetScore()
        {
            return score;
        }

        public override float GetMultiplier()
        {
            return Mathf.Min(maxMultiplier, currentDriftTime);
        }

        float GetInstantScore()
        {
            float angle = Mathf.Abs(car.GetDriftAngle());
            float speed = Mathf.Abs(car.GetVelocity().magnitude);

            if (speed < minSpeed) speed = 0;

            float rawScore = angle * speed;
            return rawScore * GetMultiplier();
        }
    }
}