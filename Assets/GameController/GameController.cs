﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
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
        public bool backwardsCheck = true;
        public Track track;
        public TimerHelper backwardsTimer;
        [Header("Collision Things")]
        public UnityEvent onCollision;
        public bool collisionCheck = true;
        [Header("Other")]
        public UnityEvent onGameOver;
        public GameOverUI gameOverUI;
        public Car.Car car;

        void Start()
        {
            offTrackTimer.onTimeout.AddListener(EndGame);
            backwardsTimer.onTimeout.AddListener(EndGame);
        }

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

        public void EndGame()
        {
            DisableGameOverChecks();
            onGameOver.Invoke();
        }

        public void OnCollision()
        {
            if (collisionCheck) EndGame();
        }

        public void DisableGameOverChecks()
        {
            backwardsCheck = false;
            offTrackCheck = false;
            collisionCheck = false;
            offTrackTimer.UpdateState(false);
            backwardsTimer.UpdateState(false);
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}