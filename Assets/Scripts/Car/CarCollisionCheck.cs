using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CarCollisionCheck : MonoBehaviour
{
    public LayerMask collidableLayer;
    public float minImpulse = 1;
    public UnityEvent onCollision;

    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if ((collidableLayer.value & 1 << collisionInfo.gameObject.layer) == 1 << collisionInfo.gameObject.layer)
        {
            if (collisionInfo.impulse.magnitude / rb.mass >= minImpulse)
            {
                onCollision.Invoke();
            }
        }
    }
}
