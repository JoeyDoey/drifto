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
        void Start()
        {
            touchInput = GetComponent<TouchInput>();
        }

        public void SetPlayerControl(bool playerInControl)
        {
            this.playerInControl = playerInControl;
        }

        public override InputState GetInput()
        {
            if (playerInControl) return new InputState(touchInput.centeredScreenPosition.x);
            else return new InputState(0);
        }
    }
}