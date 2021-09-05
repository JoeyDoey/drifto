using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace GameController
{
    public class GameStateController : MonoBehaviour
    {
        void Start()
        {
            GetStateInfo(currentState).onStart.Invoke();
        }

        // ========================================================================================
        [Header("Game State")]
        [SerializeField] GameState currentState;
        // TODO automate this - custom inspector?
        [SerializeField] GameStateInfo gameStateInfo;
        [SerializeField] GameStateInfo postgameStateInfo;

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
        }

        public GameState GetState()
        {
            return currentState;
        }

        GameStateInfo GetStateInfo(GameState state)
        {
            switch (state)
            {
                case GameState.game:
                    return gameStateInfo;
                    break;
                case GameState.postgame:
                    return postgameStateInfo;
                    break;
            }
            return postgameStateInfo;
        }

    }

    public enum GameState
    {
        game,
        postgame,
        none,
    }

    [System.Serializable]
    public class GameStateInfo
    {
        public UnityEvent onStart;
        public UnityEvent onStop;
        public GameState[] nextStates;
    }
}