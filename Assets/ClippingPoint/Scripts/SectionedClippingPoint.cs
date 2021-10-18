using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SectionedClippingPoint : AClippingPoint
{
    [SerializeField] private Collider postCollider;
    public int scorePerSection = 100;
    public float maxDistance = 5;
    public int sections = 4;

    /// <summary>
    /// Assuming the point is the the range, get the score at point
    /// </summary>
    public override float GetScore(Vector3 point) {
        return GetSection(point) * scorePerSection;
    }

    private float GetSection(Vector3 point) {
        float normalizedDistance = GetProjectedDistance(point) / maxDistance;
        if (IsInFront(point) || normalizedDistance >= 1) return 0;
        int currentSection = Mathf.FloorToInt((1 - normalizedDistance) * sections);
        if (currentSection >= sections) return 0;
        return currentSection + 1;
    } 

    public bool IsTouching(Vector3 point)
    {
        Vector3 closest = postCollider.ClosestPoint(point);
        return closest == point;
    }
}
