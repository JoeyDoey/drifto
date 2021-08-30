using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputController
{
    public abstract class AInputController : MonoBehaviour
    {
        public abstract InputState GetInput();
    }

    public struct InputState
    {
        public InputState(float steering, float acceleration)
        {
            this.steering = steering;
            this.acceleration = acceleration;
        }

        public float steering;
        public float acceleration;
    }
}