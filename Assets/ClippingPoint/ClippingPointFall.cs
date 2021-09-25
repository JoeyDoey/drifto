using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingPointFall : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            animator.SetTrigger("fall");
        }
    }
}
