using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the object to follow

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (target != null)
        {
            // Set camera position to match the object's position
            transform.position = new Vector3 (target.position.x,target.position.y,-10);

            // Optionally, you can add an offset to adjust the camera position
            // transform.position += new Vector3(0f, 2f, -5f);
        }
    }
}
