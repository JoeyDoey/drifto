using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace GameController
{
    /// <summary>
    /// Very crude state machine.
    /// </summary>
    public class GameStateController : MonoBehaviour
    {
        void Start()
        {
            GetStateInfo(currentState).onStart.Invoke();
        }

        [Header("Game State")]
        [SerializeField] GameState currentState;
        // TODO automate this - custom inspector?
        [SerializeField] GameStateInfo pregameStateInfo;
        [SerializeField] GameStateInfo gameStateInfo;
        [SerializeField] GameStateInfo postgameStateInfo;

        /// <summary>
        /// Set the state of the state machine to newState.
        /// 
        /// Calls the onStop and onStart for the last and next state respectively.
        /// 
        /// If newState is not listed as a legal next state of the current state, an error is
        /// logged with Debug.LogError.
        /// </summary>
        public void SetState(GameState newState)
        {
            if (Array.Exists(GetStateInfo(currentState).nextStates, element => element == newState))
            {
                if (newState != currentState)
                {
                    GetStateInfo(currentState).onStop.Invoke();
                    GetStateInfo(newState).onStart.Invoke();
                }
                currentState = newState;
            }
            else
            {
                Debug.LogError("Cannot change game state from " + currentState + " to " + newState);
            }
        }

        public GameState GetState()
        {
            return currentState;
        }

        /// <summary>
        /// Get the respective state info object for the given state (The thing defined in the inspector).
        /// </summary>
        GameStateInfo GetStateInfo(GameState state)
        {
            switch (state)
            {
                case GameState.pregame:
                    return pregameStateInfo;
                case GameState.game:
                    return gameStateInfo;
                case GameState.postgame:
                    return postgameStateInfo;
            }
            return postgameStateInfo;
        }

    }

    [System.Serializable]
    public enum GameState
    {
        pregame,
        game,
        postgame,
    }

    /// <summary>
    /// Defines what events are called on a state being started and stopped. Also defines what the
    /// next legal states are.
    /// </summary>
    [System.Serializable]
    public class GameStateInfo
    {
        public UnityEvent onStart;
        public UnityEvent onStop;
        public GameState[] nextStates;
    }
}