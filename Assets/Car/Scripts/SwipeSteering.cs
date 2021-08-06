using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSteering : MonoBehaviour
{
    CarController ControlledCar;
    void Start()
    {
        ControlledCar = GetComponent<CarController>();
    }

    void Update()
    {
        float x = TouchInput.centeredScreenPosition.x;
        ControlledCar.UpdateControls(x, 1f);
    }
}
