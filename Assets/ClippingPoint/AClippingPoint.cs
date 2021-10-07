using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class FloatEvent: UnityEvent<float> {}

public abstract class AClippingPoint : MonoBehaviour
{
    public int scorePerSection = 100;
    public float maxDistance = 5;
    public int sections = 4;
    public FloatEvent onScore;

    /// <summary>
    /// Assuming the point is the the range, get the score at point
    /// <summary>
    public abstract float GetScore(Vector3 point);
    /// <summary>
    /// Assuming the point is the the range, get the score of the collider
    /// <summary>
    public abstract float GetScore(Collider collider);
}