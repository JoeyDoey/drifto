using UnityEngine;

namespace GameController
{
    public abstract class AScoreController : MonoBehaviour
    {
        public ClippingPointController clippingPointController;
        [Header("Drift Score")]
        public float masterMultiplier = 1f;
        public float minSpeed = 5f;
        [Header("Drift Multiplier")]
        public float maxTimeBetweenDrift = 1f;
        public int maxMultiplier = 9;

        public abstract float GetMultiplier();
        public abstract float GetScore();
        public abstract int GetClippingPoints();
    }
}