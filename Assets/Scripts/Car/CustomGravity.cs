using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public Rigidbody body;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity -= Vector3.up * gravity * Time.fixedDeltaTime;
    }
}
