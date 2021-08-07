using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClippingPoint
{
    public class ClippingPoint : MonoBehaviour
    {
        public UnityEvent onTriggerEnter;
        public MeshRenderer meshRenderer;
        public Color onColor = Color.yellow;
        public Color offColor = Color.green;
        public float resetTime = 5f;

        void Start()
        {
            ChangeColor(onColor);
        }

        void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke();
            ChangeColor(offColor);
            Invoke("Reset", resetTime);
        }

        void Reset() {
            ChangeColor(onColor);
        }

        void ChangeColor(Color newColor) {
            meshRenderer.material.color = newColor;
        }
    }
}