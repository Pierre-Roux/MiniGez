using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GizmosLine : MonoBehaviour
{

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.GetChild(0).position, 0.5f);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.GetChild(1).position, 0.5f);

        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.GetChild(2).position, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(3).position, 0.5f);

        Transform curveTransform = transform;

        if (curveTransform.childCount < 4)
            return;

        Handles.color = Color.green;

        Vector3 p0 = curveTransform.GetChild(0).position;
        Vector3 p1 = curveTransform.GetChild(1).position;
        Vector3 p2 = curveTransform.GetChild(2).position;
        Vector3 p3 = curveTransform.GetChild(3).position;

        DrawQuadraticBezierCurve(p0, p1, p2, p3);

    }

    private void DrawQuadraticBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 lastPoint = p0;

        for (float t = 0.05f; t <= 1; t += 0.05f)
        {
            Vector3 nextPoint = CalculateBezierPoint(p0, p1, p2, p3, t);
            Handles.DrawLine(lastPoint, nextPoint);
            lastPoint = nextPoint;
        }
    }

    private Vector3 CalculateBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // Bezier formula: B(t) = (1-t)^3 * P0 + 3(1-t)^2 * t * P1 + 3(1-t) * t^2 * P2 + t^3 * P3
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

}
