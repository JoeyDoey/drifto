using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClippingPointController : MonoBehaviour
{
    public ClippingPointEvent onScore;
    public UnityEvent rawOnScore;

    int numCollisions;

    void Start()
    {
        numCollisions = 0;

        // Subscribe to all clipping point onScore events
         foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (child.TryGetComponent(out IClippingPoint clippingPoint))
                {
                    ((AClippingPoint) clippingPoint).onScore.AddListener(OnChildCollision);
                }
            }
        }
    }

    public int GetClippingPoints() {
        return numCollisions;
    }

    public void OnChildCollision(AClippingPoint clippingPoint, float score)
    {
        numCollisions += 1;
        onScore.Invoke(clippingPoint, score);
        rawOnScore.Invoke();
    }
}
