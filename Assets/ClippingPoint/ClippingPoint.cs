using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingPoint : MonoBehaviour
{

    float timeUntilEnable;
    public float disableTime = 1;
    public Collider collider;

    void Start()
    {
        timeUntilEnable = 0;
    }

    void Update()
    {
        if (timeUntilEnable > 0)
        {
            timeUntilEnable = Mathf.Max(0, timeUntilEnable - Time.deltaTime);
        }
    }

    public bool IsDisabled()
    {
        return timeUntilEnable > 0;
    }

    public void TempDisable()
    {
        timeUntilEnable = disableTime;
    }

    public float GetDistanceTo(Vector3 point)
    {
        return IsTouching(point) && !IsDisabled() ? GetRealDistance(point) : 0;
    }

    bool IsInFront(Vector3 point)
    {
        Vector3 otherVec = point - transform.position;
        Vector3 thisVec = transform.right;
        return Vector3.Cross(otherVec, thisVec).y < 0;
    }

    public bool IsTouching(Vector3 point)
    {
        Vector3 closest = collider.ClosestPoint(point);
        return closest == point;
    }

    float GetRealDistance(Vector3 point)
    {
        Vector3 distance = transform.position - point;
        Vector3 projectedDistance = Vector3.Project(distance, transform.forward);
        return projectedDistance.magnitude;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
