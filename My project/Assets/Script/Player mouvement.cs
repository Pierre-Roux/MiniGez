using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvement : MonoBehaviour
{
    public List<Transform> Curves; // Array of Bezier curves
    private int currentCurvesIndex = 0; // Index of the current segment of the curve
    private List<Transform> controlPoints = new List<Transform>(); // Array to hold control points
    public float speed = 0.1f; // Speed of player movement
    private int currentSegmentIndex = 0; // Index of the current segment of the curve
    private float t = 0.1f; // Parameter to interpolate along the curve
    private Boolean NextCurve = true; // Boolean to control the affectation of child in update
    private Boolean StopCart = false; // Boolean to control the end of the path for the cart

    void Update()
    {

        if (NextCurve == true && StopCart == false) 
        {
            if (currentCurvesIndex >= 0 && currentCurvesIndex < Curves.Count) {
                if (Curves[currentCurvesIndex] != null )
                {
                    // Iterate through each child object of the curves parent
                    for (int i = 0; i < Curves[currentCurvesIndex].childCount; i++)
                    {
                        Debug.Log(controlPoints);
                        Debug.Log(Curves[currentCurvesIndex]);
                        Debug.Log(Curves[currentCurvesIndex].GetChild(i).transform);
                        controlPoints.Add(Curves[currentCurvesIndex].GetChild(i).transform);
                    }

                    // Authorize Next Curve
                    NextCurve = false;
                }
            } 
            else 
            {
                StopCart = true;
            }
        }

        if (StopCart == false ) {
            // Move towards the point on the curve corresponding to parameter t
            transform.position = CalculateBezierPoint(controlPoints[currentSegmentIndex].position, 
                                                    controlPoints[currentSegmentIndex + 1].position, 
                                                    controlPoints[currentSegmentIndex + 2].position, 
                                                    controlPoints[currentSegmentIndex + 3].position, 
                                                    t);

            // Calculate tangent of the curve at the current parameter t
            Vector3 tangent = CalculateBezierTangent(controlPoints[currentSegmentIndex].position,
                                                    controlPoints[currentSegmentIndex + 1].position,
                                                    controlPoints[currentSegmentIndex + 2].position,
                                                    controlPoints[currentSegmentIndex + 3].position,
                                                    t);

            // Calculate rotation angle around z-axis
            float angle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;

            // Apply rotation around z-axis
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
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
                if (currentSegmentIndex >= controlPoints.Count - 1)
                {
                    // Optionally, loop back to the beginning of the curve
                    currentSegmentIndex = 0;
                    
                    // Move to the next curve
                    currentCurvesIndex += 1;

                    // Clear controlPoint
                    controlPoints.Clear();

                    // Authorize Next Curve
                    NextCurve = true;
                }
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

    private Vector3 CalculateBezierTangent(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // Bezier tangent formula: B'(t) = 3(1-t)^2 * (P1 - P0) + 6(1-t)t * (P2 - P1) + 3t^2 * (P3 - P2)
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 tangent = 3 * uu * (p1 - p0) + 6 * u * t * (p2 - p1) + 3 * tt * (p3 - p2);

        return tangent.normalized; // Normalize the tangent to get a unit vector
    }
}
