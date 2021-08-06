using UnityEngine;

public class BezierCurve {
    /// <summary>
    /// Quadratic Bezier curve (just a line)
    /// </summary>
    /// <param name="start"></param>
    /// <param name="control1"></param>
    /// <param name="control2"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Vector3 GetPoint(Vector3 start, Vector3 control1, Vector3 control2, Vector3 end, float t) {
        return GetPoint(GetPoint(start, control1, control2, t), GetPoint(control1, control2, end, t), t);
    }

    /// <summary>
    /// Quadratic Bezier curve (just a line)
    /// </summary>
    /// <param name="start"></param>
    /// <param name="control1"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Vector3 GetPoint(Vector3 start, Vector3 control1, Vector3 end, float t) {
        return GetPoint(GetPoint(start, control1, t), GetPoint(control1, end, t), t);
    }

    /// <summary>
    /// Linear Bezier curve (just a line)
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Vector3 GetPoint(Vector3 start, Vector3 end, float t) {
        return Vector3.Lerp(start, end, t);
    }
}