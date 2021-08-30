using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameController
{
    public class GameController : MonoBehaviour
    {
        [Header("Off Track Things")]
        public bool offTrackCheck = true;
        public RoadCheck carCheck;
        public TimerHelper offTrackTimer;
        [Header("Backwards Things")]
        public Track track;
        public TimerHelper backwardsTimer;
        [Header("Other")]
        public bool backwardsCheck = true;
        public GameOverUI gameOverUI;

        public Car.Car car;

        void FixedUpdate()
        {
            if (offTrackCheck)
            {
                offTrackTimer.UpdateState(!carCheck.IsOnRoad());
                offTrackTimer.UpdateTimer(Time.deltaTime);
            }
            if (backwardsCheck)
            {
                backwardsTimer.UpdateState(!track.IsMovingForward(car.rigidbody));
                backwardsTimer.UpdateTimer(Time.deltaTime);
            }
        }

        public void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    [System.Serializable]
    public class TimerHelper
    {
        public float maxTime = 1f;
        public Text text;
        public UnityEvent onStart;
        public UnityEvent onStop;
        public UnityEvent onTimeout;

        // Timer
        bool running = false;
        float currentTime = 0f;

        TimerHelper()
        {
            currentTime = maxTime;
        }

        public void UpdateState(bool newState)
        {
            if (newState && !running) Start();
            if (!newState && running) Stop();
            running = newState;
        }

        public void UpdateTimer(float dt)
        {
            if (running)
            {
                currentTime = Mathf.Max(0, currentTime - dt);
                if (currentTime == 0)
                {
                    onTimeout.Invoke();
                }
            }
            text.text = currentTime.ToString("F2");
        }

        public void Start()
        {
            running = true;
            currentTime = maxTime;
            onStart.Invoke();
        }

        public void Stop()
        {
            running = false;
            currentTime = maxTime;
            onStop.Invoke();
        }
    }
}