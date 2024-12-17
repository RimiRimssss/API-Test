using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    public GameObject objectOne, objectTwo;
    public float rayDistance = 1f;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*        // Check if there's an obstruction between objectOne and objectTwo
                if (Physics.Linecast(objectOne.transform.position, objectTwo.transform.position))
                {
                    // Logic for when there's an obstruction
                }

                // Draw a debug line between the two objects
                Debug.DrawLine(objectOne.transform.position, objectTwo.transform.position, Color.red);*/

        RayCastSample();
    }
    public void RayCastSample()
    {
        // Calculate the direction from objectOne to objectTwo
        Vector3 direction = objectTwo.transform.position - objectOne.transform.position;

        // Create the ray from objectOne's position in the direction of objectTwo
        Ray ray = new Ray(objectOne.transform.position, direction.normalized);
        RaycastHit hit;

        // Perform the raycast and check if it hits something within rayDistance
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Log the name of the object that was hit
            Debug.Log("Hit: " + hit.collider.gameObject.name);

            // Make objectOne look at objectTwo
            objectOne.transform.LookAt(objectTwo.transform.position);
        }

        // Draw the ray in the scene view for debugging
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
    }

}
