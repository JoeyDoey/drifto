using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace GameController
{
    /// <summary>
    /// Helper classes for the game over timers.
    /// Give it updates on the state of the game over check and events can be registered for:
    /// * onStart: When the countdown is (re)started: new state and not old state
    /// * onStop: When the countdown is (re)stopped: not new state and old state
    /// * onTimeout: When the countdown reaches zero: state has been false long enough
    /// 
    /// UpdateTimer and UpdateState must be called regularly for it to work.
    /// onStop is not (necessarily) called when onTimeout is.
    /// </summary>
    [System.Serializable]
    public class TimerHelper
    {
        [SerializeField] float currentTime = 0f;
        public float maxTime = 1f;
        public Text text;
        public UnityEvent onStart;
        public UnityEvent onStop;
        public UnityEvent onTimeout;
        bool running = false;

        TimerHelper()
        {
            currentTime = maxTime;
        }

        /// <summary>
        /// What's the new state of the state we're watching for.
        /// Once newState is set to true, the timer is started.
        /// </summary>
        public void UpdateState(bool newState)
        {
            if (newState && !running) Start();
            if (!newState && running) Stop();
            running = newState;
        }

        /// <summary>
        /// Update the timer by dt (seconds)
        /// Calls onTimeout (if required) and updates the text (if exists)
        /// </summary>
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

        /// <summary>
        /// Manually start the timer
        /// Should you really be doing this? UpdateTimer and UpdateState should take care of it.
        /// </summary>
        public void Start()
        {
            running = true;
            currentTime = maxTime;
            onStart.Invoke();
        }

        /// <summary>
        /// Manually stop the timer
        /// Should you really be doing this? UpdateTimer and UpdateState should take care of it.
        /// </summary>
        public void Stop()
        {
            running = false;
            currentTime = maxTime;
            onStop.Invoke();
        }
    }
}