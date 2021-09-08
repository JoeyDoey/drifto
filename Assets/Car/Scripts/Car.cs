using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    public abstract class Car : MonoBehaviour
    {
        public Transform frontCheck;
        [HideInInspector]
        public new Rigidbody rigidbody;
        public abstract Vector3 GetVelocity();
        public abstract float GetDriftAngle();
    }
}