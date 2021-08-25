using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public class SwipeSteering : MonoBehaviour
    {
        public float screenUse = 0.8f;
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
            return Mathf.Minj(Mathf.Max(-1, TouchInput.centeredScreenPosition.x * (1 / screenUse)), 1);
        }
    }
}