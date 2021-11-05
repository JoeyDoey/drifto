using System.Collections;
using System.Collections.Generic;
using PG_Physics.Wheel;
using UnityEngine;

namespace Car
{
    /// <summary>
    /// Wheel settings and update logic.
    /// </summary>
    [System.Serializable]
    public struct Wheel
    {
        public LayerMask roadLayer;
        public WheelCollider WheelCollider;
        public WheelColliderEffects wheelColliderEffects;
        public Transform WheelView;
        public float SlipForGenerateParticle;
        public Vector3 TrailOffset;

        public float CurrentMaxSlip { get { return Mathf.Max(CurrentForwardSleep, CurrentSidewaysSleep); } }
        public float CurrentForwardSleep { get; private set; }
        public float CurrentSidewaysSleep { get; private set; }
        public WheelHit GetHit { get { return Hit; } }
        bool onRoad;

        WheelHit Hit;
        TrailRenderer Trail;

        PG_WheelCollider m_PGWC;
        public PG_WheelCollider PG_WheelCollider
        {
            get
            {
                if (m_PGWC == null)
                {
                    m_PGWC = WheelCollider.GetComponent<PG_WheelCollider>();
                }
                if (m_PGWC == null)
                {
                    m_PGWC = WheelCollider.gameObject.AddComponent<PG_WheelCollider>();
                    m_PGWC.CheckFirstEnable();
                }
                return m_PGWC;
            }
        }

        // public FXController fxc;
        Vector3 HitPoint;

        const int SmoothValuesCount = 3;

        /// <summary>
        /// Update gameplay logic.
        /// </summary>
        public void FixedUpdate()
        {

            if (WheelCollider.GetGroundHit(out Hit))
            {
                onRoad = IsRoad(Hit.collider); 

                var prevForwar = CurrentForwardSleep;
                var prevSide = CurrentSidewaysSleep;

                CurrentForwardSleep = (prevForwar + Mathf.Abs(Hit.forwardSlip)) / 2;
                CurrentSidewaysSleep = (prevSide + Mathf.Abs(Hit.sidewaysSlip)) / 2;
            }
            else
            {
                CurrentForwardSleep = 0;
                CurrentSidewaysSleep = 0;
            }
        }

        /// <summary>
        /// Update visual logic (Transform, FX).
        /// </summary>
        public void UpdateVisual()
        {
            UpdateTransform();
            bool shouldEmit = WheelCollider.isGrounded && CurrentMaxSlip > SlipForGenerateParticle;
            if (wheelColliderEffects) wheelColliderEffects.SetEmiting(shouldEmit && onRoad, shouldEmit);
        }

        bool IsRoad(Collider other)
        {
            return 1 << other.gameObject.layer == roadLayer.value;
        }

        public void UpdateTransform()
        {
            Vector3 pos;
            Quaternion quat;
            WheelCollider.GetWorldPose(out pos, out quat);
            WheelView.position = pos;
            WheelView.rotation = quat;
        }

        public void UpdateFrictionConfig(PG_WheelColliderConfig config)
        {
            PG_WheelCollider.UpdateConfig(config);
        }
    }

}