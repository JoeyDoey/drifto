using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClippingPointController : MonoBehaviour
{
    public FloatEvent onScore;
    void Start()
    {
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

    public void OnChildCollision(float score)
    {
        onScore.Invoke(score);
        Debug.Log(score);
    }
}
