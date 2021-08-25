using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollisionCheck : MonoBehaviour
{
    public LayerMask collidableLayer;
    public float maxImpulse = 1;

    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if ((collidableLayer.value & 1 << collisionInfo.gameObject.layer) == 1 << collisionInfo.gameObject.layer)
        {
            if (collisionInfo.impulse.magnitude / rb.mass >= maxImpulse)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
