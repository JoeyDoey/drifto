using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace GameController
{
    [System.Serializable]
    public class TimerHelper
    {
        [SerializeField] float currentTime = 0f;
        public float maxTime = 1f;
        public Text text;
        public UnityEvent onStart;
        public UnityEvent onStop;
        public UnityEvent onTimeout;

        // Timer
        bool running = false;

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
            if (text) text.text = currentTime.ToString("F2");
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