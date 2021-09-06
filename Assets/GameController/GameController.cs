using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameController
{
    [RequireComponent(typeof(GameController))]
    public class GameController : MonoBehaviour
    {
        GameStateController gameState;
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
        public Car.Car car;

        void Start()
        {
            offTrackTimer.onTimeout.AddListener(OnTimeout);
            backwardsTimer.onTimeout.AddListener(OnTimeout);
            
            gameState = GetComponent<GameStateController>();
            gameState.SetState(GameState.game);
        }

        void OnTimeout() {
            if (gameState.GetState() == GameState.game)
            {
                gameState.SetState(GameState.postgame);
            }
        }

        void FixedUpdate()
        {
            if (gameState.GetState() == GameState.game)
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
        }

        public void OnCollision()
        {
            if (gameState.GetState() == GameState.game)
            {
                if (collisionCheck) OnTimeout();
            }
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}