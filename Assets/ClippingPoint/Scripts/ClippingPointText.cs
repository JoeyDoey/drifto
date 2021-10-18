using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingPointText : MonoBehaviour
{
    public float timeAlive = 5;
    float timer;

    private void Start() {
        timer = timeAlive;
    }

    void Update()
    {
        if (timer > 0) {
            transform.eulerAngles = Camera.main.transform.eulerAngles;
            timer -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
}
