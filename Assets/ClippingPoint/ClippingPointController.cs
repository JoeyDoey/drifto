using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingPointController : MonoBehaviour
{
    void Start()
    {
        // Subscribe to all clipping point onScore events
         foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (child.TryGetComponent(out ClippingPoint clippingPoint))
                {
                    clippingPoint.onScore.AddListener(OnChildCollision);
                }
            }
        }
    }

    public void OnChildCollision(float score)
    {
        Debug.Log(score);
    }
}
