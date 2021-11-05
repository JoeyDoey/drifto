using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputController
{
    public abstract class AInputController : MonoBehaviour
    {
        public abstract InputState GetInput();
    }

    public class InputState
    {
        public bool handBrake;
        public float steering;
        public float acceleration;
        public InputState()
        {
            acceleration = 0;
            steering = 0;
            handBrake = false;
        }
    }
}