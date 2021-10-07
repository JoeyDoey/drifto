using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClippingPoint : AClippingPoint
{
    [SerializeField] private Collider postCollider;

    private void Awake() {
        onScore = new FloatEvent();
    }

    /// <summary>
    /// Assuming the point is the the range, get the score at point
    /// </summary>
    public override float GetScore(Vector3 point) {
        return GetSection(point) * scorePerSection;
    }

    private float GetSection(Vector3 point) {
        float normalizedDistance = GetRealDistance(point) / maxDistance;
        if (IsInFront(point) || normalizedDistance >= 1) return 0;
        int currentSection = Mathf.FloorToInt((1 - normalizedDistance) * sections);
        if (currentSection >= sections) return 0;
        return currentSection + 1;
    }

    /// <summary>
    /// Assuming the point is the the range, get the score of the collider
    /// </summary>
    public override float GetScore(Collider collider) {
        return GetScore(collider.ClosestPoint(transform.position));
    }

    float GetRealDistance(Vector3 point)
    {
        Vector3 distance = transform.position - point;
        Vector3 projectedDistance = Vector3.Project(distance, transform.forward);
        return projectedDistance.magnitude;
    }

    bool IsInFront(Vector3 point)
    {
        Vector3 otherVec = point - transform.position;
        Vector3 thisVec = transform.right;
        return Vector3.Cross(otherVec, thisVec).y < 0;
    }

    public bool IsTouching(Vector3 point)
    {
        Vector3 closest = postCollider.ClosestPoint(point);
        return closest == point;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car") {
            onScore.Invoke(GetScore(other));
        }
    }
}
