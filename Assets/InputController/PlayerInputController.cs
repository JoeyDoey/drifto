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

        public override InputState GetInput()
        {
            if (playerInControl) return new InputState(touchInput.centeredScreenPosition.x, accelerating ? 1 : 0);
            else return new InputState(0, 0);
        }
    }
}