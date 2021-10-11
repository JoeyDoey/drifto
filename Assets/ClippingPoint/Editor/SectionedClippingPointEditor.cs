using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SectionedClippingPoint))]
public class SectionedClippingPointEditor : Editor
{
    SectionedClippingPoint current;
    
    void OnEnable()
    {
        current = target as SectionedClippingPoint;
    }

    private void OnSceneGUI() {
        Handles.DrawLine(current.transform.TransformPoint(Vector3.zero), current.transform.TransformPoint(Vector3.forward * current.maxDistance));

        Transform roadMark = current.gameObject.transform.Find("RoadMark");
        roadMark.localScale = new Vector3(current.maxDistance / 10, roadMark.localScale.y, roadMark.localScale.z);
        roadMark.localPosition = new Vector3(roadMark.localPosition.x, roadMark.localPosition.y, current.maxDistance / 2);
    }
}
