using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactClippingPoint : AClippingPoint
{
    public float points = 100;

    public override float GetScore(Vector3 point)
    {
        return points;
    }
}