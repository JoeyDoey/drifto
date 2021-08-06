using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeshSpline))]
public class MeshSplineEditor : Editor
{
    MeshSpline spline;

    void OnSceneGUI()
    {
        spline = (MeshSpline)target;
        if (spline)
        {
            ShowAlignmentSpline();
            ShowSplinePoints();
        }
        // spline.AlignMesh();
    }

    void ShowAlignmentSpline()
    {
        Handles.color = Color.green;
        Handles.DrawLine(spline.transform.TransformPoint(spline.meshStart), spline.transform.TransformPoint(spline.meshEnd));
    }

    void ShowSplinePoints()
    {
        for (int i = 0; i < spline.curvePoints.Length; i++)
        {
            CurvePoint point = spline.curvePoints[i];
            Handles.Label(point.position, GetPointName(i, spline.curvePoints.Length));
            switch (Tools.current)
            {
                case Tool.Move:
                    spline.curvePoints[i].position = Handles.PositionHandle(point.position, point.orientation);
                    break;
                case Tool.Rotate:
                    spline.curvePoints[i].orientation = Handles.RotationHandle(point.orientation, point.position);
                    break;
            }
        }
    }

    string GetPointName(int index, int pointsLen)
    {
        if (index == 0) return "Start Track Point";
        else if (index == pointsLen - 1) return "End Track Point";
        else if (index % 3 == 0) return "Track Point";
        else return "Control Point " + (index / 2 + 1).ToString();
    }
}
