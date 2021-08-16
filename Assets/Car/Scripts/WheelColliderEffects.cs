using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    [RequireComponent(typeof(TrailRenderer))]
    [RequireComponent(typeof(ParticleSystem))]
    public class WheelColliderEffects : MonoBehaviour
    {
        private bool emitting = false;
        TrailRenderer trail;
        ParticleSystem particles;

        public void SetEmiting(bool emitting) {
            this.emitting = emitting;
        }

        void Start() {
            trail = GetComponent<TrailRenderer>();
            particles = GetComponent<ParticleSystem>();
            particles.Stop();
            UpdateEmmiter();
        }

        void FixedUpdate() {
            UpdateEmmiter();
        }

        void UpdateEmmiter() {
            trail.emitting = emitting;
            if (emitting) particles.Play();
            else particles.Pause();
        }
    }
}