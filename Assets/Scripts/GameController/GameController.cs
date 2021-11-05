using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameController
{
    ///  <summary>
    /// Controls a lot of the movement between game states.
    /// Handles the off track and backwards timers, and the collision game over things.
    /// </summary>
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

            AppController.GameModel gameModel = AppController.AppController.Instance.GetComponent<AppController.AppModel>().gameModel;
            if (gameModel.skipMenu)
            {
                StartGame();
            }
        }

        /// <summary>
        /// If we are in the game state, change it to the postgame.
        /// To be registered as a listener for the onTimeout event for the game over timers
        /// (off track and backwards).
        /// </summary>
        void OnTimeout()
        {
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

        public void StartGame()
        {
            gameState.SetState(GameState.game);
        }

        /// <summary>
        /// How the controller knows about the car collision.
        /// The car must have this registered on the collision event.
        /// TODO make it so that this has to know about the car, not the other way around
        /// </summary>
        public void OnCollision()
        {
            if (gameState.GetState() == GameState.game)
            {
                if (collisionCheck) OnTimeout();
            }
        }

        /// <summary>
        /// Restart the game scene.
        /// Allows skipping of the menu once restarted (default is true to skipping it).
        /// </summary>
        public void RestartGame(bool skipMenu = true)
        {
            AppController.GameModel gameModel = AppController.AppController.Instance.GetComponent<AppController.AppModel>().gameModel;
            gameModel.skipMenu = skipMenu;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}