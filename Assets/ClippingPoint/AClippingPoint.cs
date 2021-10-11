using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class FloatEvent: UnityEvent<float> {}

public interface IClippingPoint {
    /// <summary>
    /// Assuming the point is the the range, get the score at point
    /// <summary>
    float GetScore(Vector3 point);
    /// <summary>
    /// Assuming the point is the the range, get the score of the collider
    /// <summary>
    float GetScore(Collider collider);
}


public abstract class AClippingPoint : MonoBehaviour, IClippingPoint
{
    public FloatEvent onScore = new FloatEvent();

    /// <summary>
    /// Assuming the point is the the range, get the score at point
    /// <summary>
    /// 
    public abstract float GetScore(Vector3 point);
    /// <summary>
    /// Assuming the point is the the range, get the score of the collider
    /// <summary>
    public float GetScore(Collider collider) {
        return GetScore(collider.ClosestPoint(transform.position));
    }

    /// <summary>
    /// How far is the point from the transform when point is projected onto the forward firection
    /// of the transform?
    /// </summary>
    protected float GetProjectedDistance(Vector3 point)
    {
        Vector3 distance = transform.position - point;
        Vector3 projectedDistance = Vector3.Project(distance, transform.forward);
        return projectedDistance.magnitude;
    }

    protected bool IsInFront(Vector3 point)
    {
        Vector3 otherVec = point - transform.position;
        Vector3 thisVec = transform.right;
        return Vector3.Cross(otherVec, thisVec).y < 0;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car") {
            onScore.Invoke(GetScore(other));
        }
    }
}
