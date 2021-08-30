using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class SwipeSteering : MonoBehaviour
    {
        public InputController.AInputController inputController;
        CarController ControlledCar;
        void Start()
        {
            ControlledCar = GetComponent<CarController>();
        }

        void Update()
        {
            InputController.InputState input = inputController.GetInput();
            ControlledCar.UpdateControls(input.steering, input.acceleration);
        }
    }
}