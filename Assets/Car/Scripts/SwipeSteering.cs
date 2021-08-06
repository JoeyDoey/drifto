using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSteering : MonoBehaviour
{
	CarController ControlledCar;
  public float power = 1;

    // Start is called before the first frame update
    void Start()
    {
		ControlledCar = GetComponent<CarController> ();
    }

    // Update is called once per frame
    void Update()
    {
      float x = TouchInput.centeredScreenPosition.x;
      float tx = Mathf.Pow(Mathf.Abs(x), power) * Mathf.Sign(x);
		ControlledCar.UpdateControls (0, 1f, false);
    }
}
