using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurvePoint
{
    public CurvePoint(Vector3 position) {
        this.position = position;
    }

    public Vector3 position;
    public Vector3 eulerAngles;
    public Quaternion orientation
    {
        get { return Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z); }
        set { eulerAngles = value.eulerAngles; }
    }
}

public class MeshSpline : MonoBehaviour
{
    public Vector3 meshStart;
    public Vector3 meshEnd;
    public MeshFilter meshFilter;
    public CurvePoint[] curvePoints = new CurvePoint[] {
        new CurvePoint(Vector3.forward * 0),
        new CurvePoint(Vector3.forward * 1),
        new CurvePoint(Vector3.forward * 2),
        new CurvePoint(Vector3.forward * 3),
    };

    void Start() {
        AlignMesh();
    }

    /// <summary>
    /// Line the mesh along the spline
    /// Messes with the vertices
    /// </summary>
    public void AlignMesh()
    {
        Vector3[] originalPoints = meshFilter.sharedMesh.vertices;
        Vector3[] newPoints = new Vector3[originalPoints.Length];

        // For each point
        for (int i = 0; i < originalPoints.Length; i++)
        {
            Vector3 point = originalPoints[i];
            newPoints[i] = AlignPoint(point);
        }

        meshFilter.mesh.vertices = newPoints;
        meshFilter.mesh.RecalculateNormals();
    }

    Vector3 AlignPoint(Vector3 point)
    {
        // Find corresponding t along alignment line
        Vector3 projVec = meshEnd - meshStart;
        Vector3 projPoint = point - meshStart;
        Vector3 alignmentPos = Vector3.Project(projPoint, projVec);
        Vector3 offset = alignmentPos - point;
        float t = alignmentPos.magnitude / projVec.magnitude;

        // Find position of t along curve
        Vector3 splinePos = BezierCurve.GetPoint(curvePoints[0].position, curvePoints[1].position, curvePoints[2].position, curvePoints[3].position, t);

        // offset position
        Vector3 final = splinePos - offset - meshStart;
        return final;
    }
}
