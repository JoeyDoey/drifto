using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public RoadCheck carCheck;
    public UnityEvent offTrack;
    public UnityEvent onTrack;

    bool last = false;
    void Update()
    {
        bool next = carCheck.IsOnRoad();
        if (next && !last) onTrack.Invoke(); 
        if (!next && last) offTrack.Invoke(); 
        last = next;
    }
}
