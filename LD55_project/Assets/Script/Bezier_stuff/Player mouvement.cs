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
    public float RotationSpeed = 0.1f; // Speed of player rotation
    private float t = 0.1f; // Parameter to interpolate along the curve
    private Boolean StopCart = false; // Boolean to control the end of the path for the cart
    private Boolean CurveBehavior = false; // Boolean to control if we are currently in a curve or not
    private Vector3 nextCurveStartPosition; // Store the start position of the next curve

    void Start()
    {
        nextCurveStartPosition = Curves[currentCurvesIndex].GetChild(0).position;
    }

    void Update()
    {

        if (CurveBehavior == true)
        {
            if (StopCart == false) 
            {
                if (currentCurvesIndex >= 0 && currentCurvesIndex < Curves.Count) {
                    if (Curves[currentCurvesIndex] != null )
                    {
                        // Iterate through each child object of the curves parent
                        for (int i = 0; i < Curves[currentCurvesIndex].childCount; i++)
                        {
                            controlPoints.Add(Curves[currentCurvesIndex].GetChild(i).transform);
                        }

                        // Store the start position of the next curve
                        if (currentCurvesIndex + 1 < Curves.Count)
                        {
                            nextCurveStartPosition = Curves[currentCurvesIndex + 1].GetChild(0).position;
                        }
                    }
                } 
                else 
                {
                    // Stop the cart it's the end off the road babe
                    StopCart = true;
                }
            }

            if (StopCart == false ) {
                // Move towards the point on the curve corresponding to parameter t
                transform.position = CalculateBezierPoint(controlPoints[0].position, 
                                                        controlPoints[ 1].position, 
                                                        controlPoints[2].position, 
                                                        controlPoints[3].position, 
                                                        t);

                // Calculate tangent of the curve at the current parameter t
                Vector3 tangent = CalculateBezierTangent(controlPoints[0].position,
                                                        controlPoints[1].position,
                                                        controlPoints[2].position,
                                                        controlPoints[3].position,
                                                        t);

                // Calculate rotation angle around z-axis
                float targetAngle = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;

                // Smoothly rotate the object towards the target angle
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            
                // Increment parameter t based on speed
                t += speed * Time.deltaTime;

                // Check if we've reached the end of the curve
                if (t >= 1f)
                {
                    // Reset parameter t
                    t = 0f;

                    // Move to the next curve
                    currentCurvesIndex += 1;

                    // Clear controlPoint
                    controlPoints.Clear();

                    // When we end a curve we stop using curve behavior
                    CurveBehavior = false;

                    // Store the start position of the next curve
                    if (currentCurvesIndex + 1 < Curves.Count)
                    {
                        nextCurveStartPosition = Curves[currentCurvesIndex].GetChild(0).position;
                    }
                    
                }
            }
        }
        else
        {
            if (nextCurveStartPosition == transform.position)
            {
                CurveBehavior = true;
                t = 0f;
            }
            else
            {
                if (currentCurvesIndex+1 > Curves.Count) {
                    StopCart = true;
                }

                if (StopCart == false) {
                    t = speed * Time.deltaTime * 15;

                    // Interpolate position towards the start position of the next curve
                    transform.position = Vector3.MoveTowards(transform.position, nextCurveStartPosition,t);

                    Vector3 direction = nextCurveStartPosition - transform.position;
                    // Calculate rotation angle around z-axis
                    float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    
                    // Smoothly rotate the object towards the target angle
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
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
