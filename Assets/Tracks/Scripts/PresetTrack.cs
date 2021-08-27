using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetTrack : Track
{
    public int maxNodeGap = 3;
    public Transform nodeParent;

    public override bool IsMovingForward(Rigidbody thing) {
        int currentIndex = ClosestNode(thing.transform.position);
        int nextIndex = ClosestNode(thing.transform.position + thing.velocity.normalized);
        int change = nextIndex - currentIndex;
        return (0 <= change && change <= maxNodeGap) || (-nodeParent.childCount - maxNodeGap < change && change < -nodeParent.childCount + maxNodeGap);
    }

    float GetDistanceToNode(int index)
    {
        float distance = 0;
        Vector3 lastPosition = nodeParent.GetChild(0).position;
        for (int i = 0; i < index; i++)
        {
            Transform node = nodeParent.GetChild(i);
            distance += (lastPosition - node.position).magnitude;
            lastPosition = node.position;
        }
        return distance;
    }

    int ClosestNode(Vector3 position)
    {
        int index = -1;
        float minDistance = Mathf.Infinity;

        int i = 0;
        foreach (Transform node in nodeParent)
        {

            float distance = (node.position - position).magnitude;
            if (distance < minDistance)
            {
                index = i;
                minDistance = distance;
            }

            i++;
        }
        return index;
    }
}
