using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    [RequireComponent(typeof(TrailRenderer))]
    [RequireComponent(typeof(ParticleSystem))]
    public class WheelColliderEffects : MonoBehaviour
    {
        bool emitSmoke = false;
        bool emitTrail = false;
        TrailRenderer trail;
        ParticleSystem particles;

        public void SetEmiting(bool smoke, bool trail) {
            emitSmoke = smoke;
            emitTrail = trail;
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
            trail.emitting = emitTrail;
            if (emitSmoke) particles.Play();
            else particles.Pause();
        }
    }
}