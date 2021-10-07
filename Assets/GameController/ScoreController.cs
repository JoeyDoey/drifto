using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameController
{
    /// Takes into consideration speed, angle, time in drift, and clipping points.
    /// </summary>
    public class ScoreController : AScoreController
    {
        public Car.Car car;
        float score;
        float currentDriftTime;
        float timeSinceDrift;

        void Awake()
        {
            score = 0;
            currentDriftTime = 0;
            timeSinceDrift = 0;
        }

        void Update()
        {
            score += GetInstantScore() * Time.deltaTime * masterMultiplier;
        }

        private void FixedUpdate() {
            if (car.IsDrifting()) {
                currentDriftTime += Time.fixedDeltaTime;
                timeSinceDrift = 0;
            } else if (timeSinceDrift < maxTimeBetweenDrift) {
                timeSinceDrift += Time.fixedDeltaTime;
            } else {
                currentDriftTime = 0;
            }
        }

        public override float GetScore()
        {
            return score;
        }

        public override float GetMultiplier()
        {
            return currentDriftTime;
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