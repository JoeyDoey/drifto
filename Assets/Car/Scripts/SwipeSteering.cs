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
            ControlledCar.UpdateControls(GetSteering(), 1f);
        }

        float GetSteering() {
            return inputController.GetInput().steering;
        }
    }
}