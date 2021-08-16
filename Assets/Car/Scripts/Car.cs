using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public abstract class Car : MonoBehaviour
    {
        public abstract Vector3 GetVelocity();
        public abstract float GetDriftAngle();
    }
}