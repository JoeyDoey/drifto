using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public abstract class Car : MonoBehaviour
    {
        [HideInInspector]
        public new Rigidbody rigidbody;
        public abstract Vector3 GetVelocity();
        public abstract float GetDriftAngle();
    }
}