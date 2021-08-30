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

        public InputState(float steering)
        {
            this.steering = steering;
        }

        // Value between -1 (left) and 1 (right)
        public float steering { get; }
    }
}