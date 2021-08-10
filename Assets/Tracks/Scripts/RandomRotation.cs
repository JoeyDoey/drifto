using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public bool lockX = false;
    public bool lockY = false;
    public bool lockZ = false;
    public int min = 0;
    public int max = 360;

    void Awake()
    {
        transform.eulerAngles = new Vector3(
            lockX ? transform.eulerAngles.x : GetRandomRotation(),
            lockY ? transform.eulerAngles.y : GetRandomRotation(),
            lockZ ? transform.eulerAngles.z : GetRandomRotation()
        );
    }

    int GetRandomRotation() {
        return Random.Range(min, max);
    }
}
