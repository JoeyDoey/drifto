using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCheck : MonoBehaviour
{
    public LayerMask roadLayer;
    public int roadCount = 0;

    public bool IsOnRoad() {
        return roadCount > 0;
    }

    bool IsRoad(Collider other) {
        return 1 << other.gameObject.layer == roadLayer.value;
    }

    void OnTriggerEnter(Collider other) {
        if (IsRoad(other)) {
            roadCount ++;
        }
    }

    void OnTriggerExit(Collider other) {
        if (IsRoad(other)) {
            roadCount --;
        }
    }
}
