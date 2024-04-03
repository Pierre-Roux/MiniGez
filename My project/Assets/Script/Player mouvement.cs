using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvement : MonoBehaviour
{
    public Transform[] controlPoints; // Array to hold control points
    public float speed = 0.1f; // Speed of player movement
    private int currentSegmentIndex = 0; // Index of the current segment of the curve
    public float t = 0.1f; // Parameter to interpolate along the curve

    void Update()
    {
        // Move towards the point on the curve corresponding to parameter t
        transform.position = CalculateBezierPoint(controlPoints[currentSegmentIndex].position, 
                                                  controlPoints[currentSegmentIndex + 1].position, 
                                                  controlPoints[currentSegmentIndex + 2].position, 
                                                  controlPoints[currentSegmentIndex + 3].position, 
                                                  t);

        Debug.Log(t);

        
        // Increment parameter t based on speed
        t += speed * Time.deltaTime;

        
        // Check if we've reached the end of the current segment
        if (t >= 1f)
        {
            // Move to the next segment
            currentSegmentIndex += 3;

            // Reset parameter t
            t = 0f;

            // Check if we've reached the end of the curve
            if (currentSegmentIndex >= controlPoints.Length - 1)
            {
                // Optionally, loop back to the beginning of the curve
                currentSegmentIndex = 0;
            }
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
