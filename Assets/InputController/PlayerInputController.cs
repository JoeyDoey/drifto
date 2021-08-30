using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputController
{
    [RequireComponent(typeof(TouchInput))]
    public class PlayerInputController : AInputController
    {
        TouchInput touchInput;
        void Start()
        {
            touchInput = GetComponent<TouchInput>();
        }
        public override InputState GetInput()
        {
            return new InputState(touchInput.centeredScreenPosition.x);
        }
    }
}