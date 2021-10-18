using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactClippingPoint : AClippingPoint
{
    public float points = 1;
    float timeSinceLastCollision = 0;
    float minTimeBetweenCollisions = 1f;

    public override float GetScore(Vector3 point)
    {
        return points;
    }

    public new void OnTriggerEnter(Collider other) {
        if (!disabled) base.OnTriggerEnter(other);
        timeSinceLastCollision = 0;
        disabled = true;
    }

    private void Update() {
        if (timeSinceLastCollision < minTimeBetweenCollisions) {
            disabled = true;
            timeSinceLastCollision += Time.deltaTime;
        } else {
            disabled = false;
        }
    }
}