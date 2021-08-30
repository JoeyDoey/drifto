using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputController
{
    [RequireComponent(typeof(TouchInput))]
    public class PlayerInputController : AInputController
    {
        public bool playerInControl = true;
        TouchInput touchInput;
        public bool accelerating = true;
        public bool handBrake = false;

        void Start()
        {
            touchInput = GetComponent<TouchInput>();
        }

        public void SetPlayerControl(bool playerInControl)
        {
            this.playerInControl = playerInControl;
        }

        public void SetAccelerating(bool accelerating)
        {
            this.accelerating = accelerating;
        }

        public void SetHandBrake(bool on)
        {
            this.handBrake = on;
        }

        public override InputState GetInput()
        {
            InputState state = new InputState();
            state.acceleration = accelerating ? 1 : 0;
            state.handBrake = handBrake;
            if (playerInControl)
            {
                state.steering = touchInput.centeredScreenPosition.x;
            }
            return state;
        }
    }
}